using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void checkPasswdLength_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length < 6)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void signUpBtn_Click(object sender, EventArgs e)
    {
        tipLabel.Text = "注册成功！";
    }
}