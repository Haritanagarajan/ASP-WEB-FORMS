using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP_WEB_FORMS
{
    public partial class User_Reg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailInput.Text) && !string.IsNullOrWhiteSpace(passwordInput.Text))
            {
                string str = "INSERT INTO USER_REG VALUES(@eid, @pwd)";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@eid", emailInput.Text);
                cmd.Parameters.AddWithValue("@pwd", passwordInput.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
            else
            {
                Response.Write("<script>alert('Email and password cannot be empty');</script>");
            }
        }


        protected void delete_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM USER_REG WHERE EMAIL = @eid";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@eid", emailInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string str = "UPDATE USER_REG SET PASSWORD = @pwd WHERE EMAIL = @eid";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@pwd", passwordInput.Text);
            cmd.Parameters.AddWithValue("@eid", emailInput.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
        }

        protected void read_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT EMAIL, PASSWORD FROM USER_REG";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            userGridView.DataSource = dt;
            userGridView.DataBind();
        }
    }
}
