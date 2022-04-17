using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AITResearch
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection myConn;
            myConn = new SqlConnection();
            myConn.ConnectionString = AppConstant.DevConnectionString;
            myConn.Open();

            SqlCommand myCommand;
            myCommand = new SqlCommand("SELECT * FROM TabUser",myConn);
            
            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", System.Type.GetType("System.String"));
            dt.Columns.Add("UserName", System.Type.GetType("System.String"));
            dt.Columns.Add("UserLevel", System.Type.GetType("System.String"));

            DataRow myRow;
            while (myReader.Read())
            {
                myRow = dt.NewRow();
                myRow["UserID"] = myReader["UserID"].ToString();
                myRow["UserName"] = myReader["UserName"].ToString();
                myRow["UserLevel"] = myReader["UserLevel"].ToString();

                dt.Rows.Add(myRow);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            myConn.Close();
        }
    }
}