using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace ASP_WEB_FORMS
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (AuthenticateUser(txtID.Text, txtName.Text, txtPassword.Text))
                {
                    string sessionID = Session["ID"] as string;
                    string sessionName = Session["Name"] as string;
                    string sessionPassword = Session["Password"] as string;

                    if (sessionID == txtID.Text && sessionName == txtName.Text && sessionPassword == txtPassword.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully logged in');", true);
                    }
                    else
                    {
                       Response.Write("<script>alert('Invalid credentials. Please try again.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials. Please try again.');</script>");
                }
            }
        }

        private bool AuthenticateUser(string id, string name, string password)
        {
            bool isAuthenticated = false;

            string connectionString = WebConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

            string query = "SELECT COUNT(*) FROM EMPLOYEE_TABLE WHERE ID = @ID AND NAME = @Name AND PASSWORD = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        isAuthenticated = count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
           
                Response.Write("<script>alert('An error occurred while authenticating. Please try again later.');</script>");

            }
            catch (Exception ex)
            {
               
                Response.Write("<script>alert('An unexpected error occurred. Please try again later.');</script>");
               
            }

            return isAuthenticated;
        }

    }
}
