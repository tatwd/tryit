using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using Bll;
using MySql.Data.MySqlClient;

namespace Ui
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(StuIdTb.Text.Trim());

            try
            {
                List<Student> list = StudentService.GetStudent(id);

                ViewData.DataSource = list;
                ViewData.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}