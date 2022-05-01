using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace AITResearch.Staff
{
    public partial class Login : System.Web.UI.Page
    {
        List<String> listUserName = new List<string>();
        List<String> listPassword = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = Utils.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TabUser", conn);
                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();

                // Database table for Question
                DataTable staffDB = new DataTable();
                staffDB.Columns.Add("UserID", System.Type.GetType("System.String"));
                staffDB.Columns.Add("UserName", System.Type.GetType("System.String"));
                staffDB.Columns.Add("Password", System.Type.GetType("System.String"));
                DataRow staffMember;


                while (rd.Read())
                {
                    staffMember = staffDB.NewRow();
                    //Different columns with their name and type
                    staffMember["UserID"] = rd["UserID"].ToString();
                    staffMember["UserName"] = rd["UserName"].ToString();
                    staffMember["Password"] = rd["Password"].ToString();
                    listUserName.Add(staffMember["UserName"].ToString());
                    listPassword.Add(staffMember["Password"].ToString());
                }
                conn.Close();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int flat = 0;
            foreach (String username in listUserName)
            {
                if (username == txtBoxUerName.Text)
                {
                    LoginStatus.Text = "";
                    if (listPassword[flat] == txtBoxPassword.Text)
                    {
                        LoginStatus.Text = "";
                        Response.Redirect("Search.aspx");
                    }
                    else
                    {
                        LoginStatus.Text = "Wrong password";
                    }
                }
                else
                {
                    LoginStatus.Text = "User not found";
                }
                flat++;
            }
        }


    }
}