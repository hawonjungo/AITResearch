using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace AITResearch
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Respondent_id"] = null;
            Session["Q_Num"] = 1;
            Session["Q_NumDisplay"] = 1;
        }

        protected void BtnStart_Click(object sender, EventArgs e)
        {
            // get Respondent Email
            //Session["RespondentEmail"] = TxtBoxEmail.Text;

            // Yes No Direction from Radiobutton
            if (Radio1Yes.Checked)
            {
                using (SqlConnection conn = Utils.GetConnection())
                {
                    String query = "INSERT INTO R_Register (First_Nam, Last_Name, Phone_Number, DoB) VALUES (@First_Nam, @Last_Name, @Phone_Number, @DoB)";

                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@register", 0);

                        String id = command.ExecuteScalar().ToString();

                        Session["Respondent_id"] = id;
                    }

                    conn.Close();
                }
                Response.Redirect("Register.aspx");
            }
            else
            {
                Response.Redirect("Questions.aspx");
            }
        }
    }
}