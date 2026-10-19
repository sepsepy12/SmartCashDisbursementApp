using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
    public class BudgetRepository
    {
        public List<BudgetCategory> GetCategoriesForUser(int userId)
        {
            var categories = new List<BudgetCategory>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT bc.id, bc.category_name,
                           COALESCE(SUM(CASE WHEN t.type = 'deposit' THEN t.amount ELSE 0 END), 0) AS allocated,
                           COALESCE(SUM(CASE WHEN t.type = 'withdrawal' THEN t.amount ELSE 0 END), 0) AS spent
                    FROM budget_categories bc
                    LEFT JOIN transactions t ON t.category_id = bc.id
                    WHERE bc.user_id = @userId
                    GROUP BY bc.id, bc.category_name";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new BudgetCategory
                            {
                                Name = reader.GetString("category_name"),
                                Allocated = reader.GetDecimal("allocated"),
                                Spent = reader.GetDecimal("spent")
                            });
                        }
                    }
                }
            }

            return categories;
        }

        public int GetOrCreateCategoryId(int userId, string categoryName, MySqlConnection conn)
        {
            string selectSql = "SELECT id FROM budget_categories WHERE user_id = @userId AND category_name = @name";
            using (var cmd = new MySqlCommand(selectSql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@name", categoryName);
                var result = cmd.ExecuteScalar();
                if (result != null) return System.Convert.ToInt32(result);
            }

            string insertSql = "INSERT INTO budget_categories (user_id, category_name, allocated_amount) VALUES (@userId, @name, 0); SELECT LAST_INSERT_ID();";
            using (var cmd = new MySqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@name", categoryName);
                return System.Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void SaveGoal(int userId, int categoryId, decimal targetAmount, System.DateTime targetDate)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO goals (user_id, category_id, target_amount, target_date) VALUES (@userId, @categoryId, @amount, @date)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@amount", targetAmount);
                    cmd.Parameters.AddWithValue("@date", targetDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}