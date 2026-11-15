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

            int authenticatedUserId = 0;
            string authenticatedFullName = string.Empty;
            string? authenticatedRole = null;
            bool loginSucceeded = false;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id, password_hash, full_name, role, is_active FROM users WHERE rfid_uid = @uid";
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
                                string? role = reader["role"] is DBNull ? null : Convert.ToString(reader["role"]);
                                bool isActive = reader["is_active"] is not DBNull && Convert.ToBoolean(reader["is_active"]);

                                if (BCrypt.Net.BCrypt.Verify(enteredPin, storedHash))
                                {
                                    if (!isActive)
                                    {
                                        MessageBox.Show("This account is inactive. Please contact an administrator.");
                                    }
                                    else if (role != "user" && role != "admin")
                                    {
                                        MessageBox.Show("This account has an invalid role and cannot log in.");
                                    }
                                    else
                                    {
                                        authenticatedUserId = userId;
                                        authenticatedFullName = fullName;
                                        authenticatedRole = role;
                                        loginSucceeded = true;
                                    }
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

                    if (loginSucceeded && authenticatedRole == "admin")
                        SystemActivityLogger.Log(conn, authenticatedUserId, "ADMIN_LOGIN", null, "Administrator signed in.");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("The login could not be completed because of a database error. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("The login could not be completed. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!loginSucceeded)
                return;

            this.Hide();
            Form dashboard = authenticatedRole == "admin"
                ? new AdminDashboardForm(authenticatedUserId, authenticatedFullName)
                : new DashboardForm(authenticatedUserId, authenticatedFullName, authenticatedRole!);
            dashboard.FormClosed += (s, args) =>
            {
                bool isSigningOut = dashboard is AdminDashboardForm adminDashboard
                    ? adminDashboard.IsSigningOut
                    : dashboard is DashboardForm userDashboard && userDashboard.IsSigningOut;

                if (isSigningOut)
                {
                    txtRfidUid.Clear();
                    txtPin.Clear();
                    WindowState = FormWindowState.Normal;
                    Show();
                    Activate();
                    txtRfidUid.Focus();
                }
                else
                {
                    Close();
                }
            };
            dashboard.Show();
        }

        private void txtRfidUid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}