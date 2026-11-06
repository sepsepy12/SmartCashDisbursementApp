using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
    public sealed class AnalyticsCategory
    {
        public string Name { get; set; } = string.Empty;
        public decimal MonthlyWithdrawals { get; set; }
        public decimal AvailableBalance { get; set; }
    }

    public sealed class DailySpending
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

    public sealed class RecentTransaction
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string CategoryName { get; set; } = "Uncategorized";
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BudgetRepository
    {
        public decimal GetMonthlyTransactionTotal(int userId, string type, DateTime monthStart, DateTime nextMonthStart)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT COALESCE(SUM(amount), 0)
                    FROM transactions
                    WHERE user_id = @userId
                      AND type = @type
                      AND created_at >= @monthStart
                      AND created_at < @nextMonthStart";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@monthStart", monthStart);
                    cmd.Parameters.AddWithValue("@nextMonthStart", nextMonthStart);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public decimal GetOverallBalance(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT COALESCE(SUM(CASE WHEN type = 'deposit' THEN amount ELSE -amount END), 0)
                    FROM transactions
                    WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public List<AnalyticsCategory> GetAnalyticsCategories(int userId, DateTime monthStart, DateTime nextMonthStart)
        {
            var categories = new List<AnalyticsCategory>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT bc.category_name,
                           COALESCE(SUM(CASE WHEN t.type = 'withdrawal'
                                              AND t.created_at >= @monthStart
                                              AND t.created_at < @nextMonthStart
                                             THEN t.amount ELSE 0 END), 0) AS monthly_withdrawals,
                           COALESCE(SUM(CASE WHEN t.type = 'deposit' THEN t.amount ELSE -t.amount END), 0) AS available_balance
                    FROM budget_categories bc
                    LEFT JOIN transactions t
                      ON t.category_id = bc.id
                     AND t.user_id = bc.user_id
                    WHERE bc.user_id = @userId
                    GROUP BY bc.id, bc.category_name
                    ORDER BY bc.id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@monthStart", monthStart);
                    cmd.Parameters.AddWithValue("@nextMonthStart", nextMonthStart);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new AnalyticsCategory
                            {
                                Name = reader.GetString("category_name"),
                                MonthlyWithdrawals = reader.GetDecimal("monthly_withdrawals"),
                                AvailableBalance = reader.GetDecimal("available_balance")
                            });
                        }
                    }
                }
            }
            return categories;
        }

        public List<DailySpending> GetDailyWithdrawals(int userId, DateTime monthStart, DateTime nextMonthStart)
        {
            var spending = new List<DailySpending>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT DATE(created_at) AS spending_date, COALESCE(SUM(amount), 0) AS daily_amount
                    FROM transactions
                    WHERE user_id = @userId
                      AND type = 'withdrawal'
                      AND created_at >= @monthStart
                      AND created_at < @nextMonthStart
                    GROUP BY DATE(created_at)
                    ORDER BY spending_date";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@monthStart", monthStart);
                    cmd.Parameters.AddWithValue("@nextMonthStart", nextMonthStart);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spending.Add(new DailySpending
                            {
                                Date = reader.GetDateTime("spending_date"),
                                Amount = reader.GetDecimal("daily_amount")
                            });
                        }
                    }
                }
            }
            return spending;
        }

        public List<RecentTransaction> GetRecentTransactions(int userId, int limit = 6)
        {
            var transactions = new List<RecentTransaction>();
            limit = Math.Max(1, limit);
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT t.id, t.type, t.amount, t.created_at,
                           COALESCE(bc.category_name, 'Uncategorized') AS category_name
                    FROM transactions t
                    LEFT JOIN budget_categories bc
                      ON bc.id = t.category_id
                     AND bc.user_id = t.user_id
                    WHERE t.user_id = @userId
                    ORDER BY t.created_at DESC, t.id DESC
                    LIMIT @limit";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@limit", limit);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactions.Add(new RecentTransaction
                            {
                                Id = reader.GetInt32("id"),
                                Type = reader.GetString("type"),
                                CategoryName = reader.GetString("category_name"),
                                Amount = reader.GetDecimal("amount"),
                                CreatedAt = reader.GetDateTime("created_at")
                            });
                        }
                    }
                }
            }
            return transactions;
        }

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
                    LEFT JOIN transactions t
                        ON t.category_id = bc.id
                       AND t.user_id = bc.user_id
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

        public int GetOrCreateCategoryId(int userId, string categoryName, MySqlConnection conn, MySqlTransaction transaction = null)
        {
            string selectSql = "SELECT id FROM budget_categories WHERE user_id = @userId AND category_name = @name";
            using (var cmd = transaction == null
                ? new MySqlCommand(selectSql, conn)
                : new MySqlCommand(selectSql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@name", categoryName);
                var result = cmd.ExecuteScalar();
                if (result != null) return System.Convert.ToInt32(result);
            }

            string insertSql = "INSERT INTO budget_categories (user_id, category_name, allocated_amount) VALUES (@userId, @name, 0); SELECT LAST_INSERT_ID();";
            using (var cmd = transaction == null
                ? new MySqlCommand(insertSql, conn)
                : new MySqlCommand(insertSql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@name", categoryName);
                return System.Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int? FindCategoryId(int userId, string categoryName)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT id FROM budget_categories WHERE user_id = @userId AND category_name = @name";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@name", categoryName);
                    var result = cmd.ExecuteScalar();
                    return result == null || result == System.DBNull.Value ? null : System.Convert.ToInt32(result);
                }
            }
        }

        public decimal GetCategoryBalance(int userId, string categoryName)
        {
            int? categoryId = FindCategoryId(userId, categoryName);
            if (!categoryId.HasValue)
                return 0;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return GetCategoryBalance(userId, categoryId.Value, conn, null);
            }
        }

        public bool TryWithdraw(int userId, string categoryName, decimal amount, out decimal remainingBalance, out string failureReason)
        {
            remainingBalance = 0;
            failureReason = null;

            if (amount <= 0)
            {
                failureReason = "The withdrawal amount must be greater than zero.";
                return false;
            }

            if (amount != decimal.Round(amount, 2))
            {
                failureReason = "The withdrawal amount must not have more than two decimal places.";
                return false;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        const string categorySql = @"
                            SELECT id
                            FROM budget_categories
                            WHERE user_id = @userId AND category_name = @categoryName
                            FOR UPDATE";

                        int categoryId;
                        using (var categoryCommand = new MySqlCommand(categorySql, conn, transaction))
                        {
                            categoryCommand.Parameters.AddWithValue("@userId", userId);
                            categoryCommand.Parameters.AddWithValue("@categoryName", categoryName);
                            var result = categoryCommand.ExecuteScalar();
                            if (result == null || result == System.DBNull.Value)
                            {
                                transaction.Rollback();
                                failureReason = "The selected category does not exist for this user.";
                                return false;
                            }

                            categoryId = System.Convert.ToInt32(result);
                        }

                        remainingBalance = GetCategoryBalance(userId, categoryId, conn, transaction);
                        if (amount > remainingBalance)
                        {
                            transaction.Rollback();
                            failureReason = "The requested amount is greater than the selected category balance.";
                            return false;
                        }

                        const string insertSql = @"
                            INSERT INTO transactions (user_id, category_id, type, amount)
                            VALUES (@userId, @categoryId, 'withdrawal', @amount)";
                        using (var insertCommand = new MySqlCommand(insertSql, conn, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("@userId", userId);
                            insertCommand.Parameters.AddWithValue("@categoryId", categoryId);
                            insertCommand.Parameters.AddWithValue("@amount", amount);
                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        remainingBalance -= amount;
                        return true;
                    }
                    catch
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                        }

                        throw;
                    }
                }
            }
        }

        private decimal GetCategoryBalance(int userId, int categoryId, MySqlConnection conn, MySqlTransaction transaction)
        {
            const string sql = @"
                SELECT
                    COALESCE(SUM(CASE WHEN type = 'deposit' THEN amount ELSE 0 END), 0) -
                    COALESCE(SUM(CASE WHEN type = 'withdrawal' THEN amount ELSE 0 END), 0)
                FROM transactions
                WHERE user_id = @userId AND category_id = @categoryId";

            using (var cmd = transaction == null
                ? new MySqlCommand(sql, conn)
                : new MySqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                return System.Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public List<SavedGoal> GetGoalsForUser(int userId)
        {
            var goals = new List<SavedGoal>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT g.id,
                           bc.category_name,
                           g.target_amount,
                           g.target_date,
                           COALESCE(SUM(CASE WHEN t.type = 'deposit' THEN t.amount ELSE 0 END), 0)
                           - COALESCE(SUM(CASE WHEN t.type = 'withdrawal' THEN t.amount ELSE 0 END), 0) AS current_balance
                    FROM goals g
                    INNER JOIN budget_categories bc
                        ON bc.id = g.category_id
                       AND bc.user_id = g.user_id
                    LEFT JOIN transactions t
                        ON t.category_id = bc.id
                       AND t.user_id = bc.user_id
                    WHERE g.user_id = @userId
                    GROUP BY g.id, bc.category_name, g.target_amount, g.target_date
                    ORDER BY g.target_date, g.id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            goals.Add(new SavedGoal
                            {
                                Id = reader.GetInt32("id"),
                                CategoryName = reader.GetString("category_name"),
                                TargetAmount = reader.GetDecimal("target_amount"),
                                TargetDate = reader.GetDateTime("target_date"),
                                CurrentBalance = reader.GetDecimal("current_balance")
                            });
                        }
                    }
                }
            }

            return goals;
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