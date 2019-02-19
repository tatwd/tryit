using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection connecter = new Connection("MySQL");

            String connectString = "server=localhost;user id=root;database=test;pwd=root";
            String sql = "SELECT * FROM stu";

            System.Data.DataSet data = connecter.GetDataSetOfDb(connectString, sql);

            GridView view = new GridView
            {
                DataSource = data
            };
            
            view.DataBind();

            form1.Controls.Add(view);
        }
    }

    public class Connection
    {
        private String DbType { get; set; }

        public Connection()
        {
            this.DbType = "MSServer";  // default value
        }

        public Connection(String dbType)
        {
            this.DbType = dbType;
        }

        public System.Data.DataSet GetDataSetOfDb(String connectString, String queryString)
        {
            if (this.DbType != "MySQL")
            {
                using (System.Data.SqlClient.SqlConnection connecter = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    try
                    {
                        System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(queryString, connecter);

                        System.Data.DataSet data = new System.Data.DataSet();

                        adapter.Fill(data);

                        return data;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        return null;
                    }
                }
            }
            else
            {
                using (MySql.Data.MySqlClient.MySqlConnection connecter = new MySql.Data.MySqlClient.MySqlConnection(connectString))
                {
                    try
                    {
                        //System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(queryString, connecter);

                        MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, connecter);

                        System.Data.DataSet data = new System.Data.DataSet();

                        adapter.Fill(data);

                        return data;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        return null;
                    }
                }
            }
        }
    }
}
