using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

namespace AITResearch.SearchPage
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // to clear the gridview old data
            gvSearchResult.DataSource = null;
            // using the connection from the Utils
            using (SqlConnection conn = Utils.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                StringBuilder sbCommand = new StringBuilder("Select * from R_Register where 1 = 1");
                // if the textbox is not empty
                if (txtBoxFirstName.Text !="")
                {
                    sbCommand.Append(" AND First_Name=@First_Name");
                    // compare the first name from database to the textbox
                    SqlParameter param = new SqlParameter("@First_Name", txtBoxFirstName.Text);
                    cmd.Parameters.Add(param);

                    cmd.CommandText = sbCommand.ToString();
                    cmd.CommandType = CommandType.Text;

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvSearchResult.DataSource = reader;
                    gvSearchResult.DataBind();
                    conn.Close();
                }
                else
                {
                    StringBuilder drCommand = new StringBuilder("Select * from R_Answer where 1 = 1");
                    // using the dropDown to check on text if not empty
                    if (dropState.Text != "")
                    {
                        foreach (ListItem item in dropState.Items)
                        {
                            if (item.Selected == true)
                            {
                                drCommand.Append(" AND Answer_Text=@Answer_Text");
                                SqlParameter param = new SqlParameter("@Answer_Text", item.Value);
                                cmd.Parameters.Add(param);
                            }

                        }
                    }
                    else if (dropBankName.Text != "")
                    {
                        foreach (ListItem item in dropBankName.Items)
                        {
                            if (item.Selected == true)
                            {
                                drCommand.Append(" AND Answer_Text=@Answer_Text");
                                SqlParameter param = new SqlParameter("@Answer_Text", item.Value);
                                cmd.Parameters.Add(param);
                            }

                        }
                    }
                    else if (dropBankService.Text != "")
                    {
                        foreach (ListItem item in dropBankService.Items)
                        {
                            if (item.Selected == true)
                            {
                                drCommand.Append(" AND Answer_Text=@Answer_Text");
                                SqlParameter param = new SqlParameter("@Answer_Text", item.Value);
                                cmd.Parameters.Add(param);
                            }

                        }
                    }

                    cmd.CommandText = drCommand.ToString();
                    cmd.CommandType = CommandType.Text;

                    conn.Open();
                    SqlDataReader readerDrop = cmd.ExecuteReader();
                    gvSearchResult.DataSource = readerDrop;
                    gvSearchResult.DataBind();
                    conn.Close();

                }

               


            }

        }
    }
}