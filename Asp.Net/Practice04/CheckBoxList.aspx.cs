using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckBoxList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBoxList1.Items[0].Text = "语文";
        CheckBoxList1.Items[1].Text = "数学";
        CheckBoxList1.Items[2].Text = "英语";
        CheckBoxList1.Items[3].Text = "物理";
        CheckBoxList1.Items[4].Text = "化学";
        CheckBoxList1.Items[5].Text = "生物";

        Label1.Text = "你的选择: ";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                Label1.Text += CheckBoxList1.Items[i].Text + " ";
            }
        }
    }
}