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
            

            // Yes No Direction from Radiobutton
            if (Radio2No.Checked)
            {
                using (SqlConnection conn = Utils.GetConnection())
                {
                    String query = "INSERT INTO R_Session (Register) VALUES (@Register) select SCOPE_IDENTITY()";


                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Register", "Anonymous");

                        // error with ID ( same number - not update)
                        String id = command.ExecuteScalar().ToString();

                        Session["Respondent_id"] = id;
                    }

                    conn.Close();
                }
                Response.Redirect("Questions.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }
    }
}