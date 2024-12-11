using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameroomManager.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ErrorLabel.Text = "Username and password are required.";
                return;
            }

            if (IsValidUser(username, password))
            {
                // Set the auth cookie
                FormsAuthentication.SetAuthCookie(username, true);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ErrorLabel.Text = "Invalid username or password.";
            }
        }
        private bool IsValidUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                string query = "SELECT PasswordHash, Salt FROM BaseUser WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();
                    string storedSalt = reader["Salt"].ToString();
                    return VerifyPassword(password, storedSalt, storedHash);
                }
            }

            return false;
        }
        private bool VerifyPassword(string password, string salt, string storedHash)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                string computedHash = Convert.ToBase64String(deriveBytes.GetBytes(32));
                return storedHash == computedHash;
            }
        }
    }
}