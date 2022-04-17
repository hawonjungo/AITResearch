using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITResearch
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnStart_Click(object sender, EventArgs e)
        {
            Session["RespondentEmail"] = TxtBoxEmail.Text;

            if (Radio1Yes.Checked)
            {

            }else
            {
                Response.Redirect("Questions.aspx");
            }
        }
    }
}