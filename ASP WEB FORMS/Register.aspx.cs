using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml.Linq;

namespace ASP_WEB_FORMS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = txtID.Text;
                string name = txtName.Text;
                string password = txtPassword.Text;

                Session["ID"] = id;
                Session["Name"] = name;
                Session["Password"] = password;

                if (InsertEmployeeData(id, name, password))
                {
                    Response.Redirect("LoginForm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                }
            }
        }


        private bool InsertEmployeeData(string id, string name, string password)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

            string query = "INSERT INTO EMPLOYEE_TABLE (ID, NAME, PASSWORD) VALUES (@ID, @Name, @Password)";

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

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                
                Response.Write("<script>alert('An error occurred while registering. Please try again later.');</script>");
               
                return false;
            }
            catch (Exception ex)
            {
              
                Response.Write("<script>alert('An unexpected error occurred. Please try again later.');</script>");
              
                return false;
            }
        }
    }
}
