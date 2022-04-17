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
    public partial class Questions : System.Web.UI.Page
    {
        string questionText;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            // Load from database
            SqlConnection myConn;
            myConn = new SqlConnection();
            myConn.ConnectionString = AppConstant.DevConnectionString;
            myConn.Open();

            SqlCommand myCommand;
            myCommand = new SqlCommand("SELECT * FROM Questions", myConn);

            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();

            // Database table for Question
            DataTable questionDB = new DataTable();
            questionDB.Columns.Add("Q_ID", System.Type.GetType("System.String"));
            questionDB.Columns.Add("Q_Text", System.Type.GetType("System.String"));
            questionDB.Columns.Add("Q_Type", System.Type.GetType("System.String"));
            questionDB.Columns.Add("Next_Q_ID", System.Type.GetType("System.String"));
            DataRow myRow;
            while (myReader.Read())
            {
                
                myRow = questionDB.NewRow();
                myRow["Q_ID"] = myReader["Q_ID"].ToString();
                myRow["Q_Text"] = myReader["Q_Text"].ToString();
                myRow["Q_Type"] = myReader["Q_Type"].ToString();
                myRow["Next_Q_ID"] = myReader["Next_Q_ID"].ToString();
                if (int.Parse((string)myRow["Q_ID"]) == AppSession.getQuestionNumber())
                {
                    questionText = myRow["Q_Text"].ToString();
                    questionDB.Rows.Add(myRow);
                }
                dbTableView.DataSource = questionDB;
                dbTableView.DataBind();

            }
            myConn.Close();

            myConn.Open();

            SqlCommand Q_OptionCommand;
            Q_OptionCommand = new SqlCommand("SELECT * FROM Question_Options", myConn);

            SqlDataReader Q_OptionReader;
            Q_OptionReader = Q_OptionCommand.ExecuteReader();
            // Database table for Question Option
            DataTable Q_OptionDB = new DataTable();
            Q_OptionDB.Columns.Add("Q_ID", System.Type.GetType("System.String"));
            Q_OptionDB.Columns.Add("QO_ID", System.Type.GetType("System.String"));
            Q_OptionDB.Columns.Add("Option_Text", System.Type.GetType("System.String"));
            Q_OptionDB.Columns.Add("Next_Q_ID", System.Type.GetType("System.String"));
            DataRow Q_OptionRow;
            while (Q_OptionReader.Read())
            {
                Q_OptionRow = Q_OptionDB.NewRow();
                Q_OptionRow["Q_ID"] = Q_OptionReader["Q_ID"].ToString();
                Q_OptionRow["QO_ID"] = Q_OptionReader["QO_ID"].ToString();
                Q_OptionRow["Option_Text"] = Q_OptionReader["Option_Text"].ToString();
                Q_OptionRow["Next_Q_ID"] = Q_OptionReader["Next_Q_ID"].ToString();

                if (int.Parse((string)Q_OptionRow["Q_ID"]) == AppSession.getQuestionNumber())
                {
                    Q_OptionDB.Rows.Add(Q_OptionRow);

                }
                

                TbQ_OptionView.DataSource = Q_OptionDB;
                TbQ_OptionView.DataBind();
            }


                myConn.Close();




            if (!IsPostBack)
                LabQuestion.Text = AppSession.getQuestionNumber() + ". " + questionText;

            if (AppSession.getQuestionNumber() == 1)
            {

                RadioButtonList radioBtnList = new RadioButtonList();
                radioBtnList.Items.Add(new ListItem("Male"));
                radioBtnList.Items.Add(new ListItem("Female"));

                PlaceHolder1.Controls.Add(radioBtnList);
            }
            else if (AppSession.getQuestionNumber() == 2)
            {
                RadioButtonList radioBtnList = new RadioButtonList();
                radioBtnList.Items.Add(new ListItem("Under 18"));
                radioBtnList.Items.Add(new ListItem("18-25"));
                radioBtnList.Items.Add(new ListItem("26-35"));
                radioBtnList.Items.Add(new ListItem("36-50"));
                radioBtnList.Items.Add(new ListItem("Over 51"));
                PlaceHolder1.Controls.Add(radioBtnList);
            }
            else if (AppSession.getQuestionNumber() == 3)
            {
                DropDownList dropDownList = new DropDownList();
                dropDownList.Items.Add(new ListItem("Western Australia"));
                dropDownList.Items.Add(new ListItem("Northern Territory"));
                dropDownList.Items.Add(new ListItem("Queensland"));
                dropDownList.Items.Add(new ListItem("South Australia"));
                dropDownList.Items.Add(new ListItem("New South Wales"));
                dropDownList.Items.Add(new ListItem("Victoria"));
                dropDownList.Items.Add(new ListItem("Tasmania"));
                PlaceHolder1.Controls.Add(dropDownList);
            }
            else if (AppSession.getQuestionNumber() == 4)
            {
                TextBox txtBoxPostCode = new TextBox();
                PlaceHolder1.Controls.Add(txtBoxPostCode);
                txtBoxPostCode.Text = String.Empty;
            }
            else if (AppSession.getQuestionNumber() == 5)
            {
                TextBox txtBoxEmail = new TextBox();
                PlaceHolder1.Controls.Add(txtBoxEmail);
                txtBoxEmail.Text = String.Empty;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            AppSession.setQuestionNumber(AppSession.getQuestionNumber() + 1);
            LabQuestion.Text = AppSession.getQuestionNumber() + ". "+ questionText;

           
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (AppSession.getQuestionNumber() > 1)
            {
                AppSession.setQuestionNumber(AppSession.getQuestionNumber() - 1);
                LabQuestion.Text = AppSession.getQuestionNumber() + ". " + questionText;
            }
            
        }
    }
}