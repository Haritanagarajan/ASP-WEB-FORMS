using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ASP_WEB_FORMS
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate the input fields
            if (Page.IsValid)
            {
                // Authenticate user
                if (AuthenticateUser(txtID.Text, txtName.Text, txtPassword.Text))
                {
                    // Redirect to CRUD page if authentication succeeds
                    Response.Redirect("Snacks.aspx");
                }
                else
                {
                    // Display error message if authentication fails
                    Response.Write("<script>alert('Invalid credentials. Please try again.');</script>");
                }
            }
        }

        // Method to authenticate user against database
        private bool AuthenticateUser(string id, string name, string password)
        {
            // Connection string to your database
            string connectionString = WebConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

            // SQL query to check if provided credentials exist in the database
            string query = "SELECT COUNT(*) FROM EMPLOYEE_TABLE WHERE ID = @ID AND NAME = @Name AND PASSWORD = @Password";

            // Using statement ensures that resources are freed after execution
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, user exists in the database
                    return count > 0;
                }
            }
        }
    }
}
