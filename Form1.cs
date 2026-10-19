namespace SmartCashDisbursementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional initialization when the login form loads
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string rfidUid = txtRfidUid.Text.Trim();
            string enteredPin = txtPin.Text.Trim();

            if (string.IsNullOrEmpty(rfidUid) || string.IsNullOrEmpty(enteredPin))
            {
                MessageBox.Show("Please enter both RFID UID and PIN.");
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, password_hash, full_name FROM users WHERE rfid_uid = @uid";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", rfidUid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("id");
                            string storedHash = reader.GetString("password_hash");
                            string fullName = reader.GetString("full_name");

                            if (BCrypt.Net.BCrypt.Verify(enteredPin, storedHash))
                            {
                                this.Hide();
                                var dashboard = new DashboardForm(userId, fullName);
                                dashboard.FormClosed += (s, args) => this.Close();
                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect PIN.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("RFID card not recognized.");
                        }
                    }
                }
            }
        }

        private void txtRfidUid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}