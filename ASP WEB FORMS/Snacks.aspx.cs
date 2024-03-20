using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ASP_WEB_FORMS
{
    public partial class Snacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private SqlConnection ConnectDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        private void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = ConnectDB())
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection connection = ConnectDB())
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM snacks", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@snackName", txtSnackName.Text),
                new SqlParameter("@snackAmount", Convert.ToInt32(txtSnackAmount.Text))
            };
            ExecuteStoredProcedure("InsertSnack", parameters);
            BindGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Id", Convert.ToInt32(txtId.Text)),
                new SqlParameter("@snackName", txtSnackName.Text),
                new SqlParameter("@snackAmount", Convert.ToInt32(txtSnackAmount.Text))
            };
            ExecuteStoredProcedure("UpdateSnack", parameters);
            BindGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Id", Convert.ToInt32(txtId.Text))
            };
            ExecuteStoredProcedure("DeleteSnack", parameters);
            BindGrid();
        }
    }
}
