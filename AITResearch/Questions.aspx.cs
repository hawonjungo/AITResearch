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
        // declair data holder
        private int QuestNum = 0;
        private string questionText;
        private DropDownList dropDownList = new DropDownList();
        private TextBox txtBoxEmail = new TextBox();
        private TextBox txtBoxPostCode = new TextBox();

        // create next_quest_id holder



        protected void Page_Load(object sender, EventArgs e)
        {
            QuestNum = Convert.ToInt32(Session["Q_Num"]);


            // Load from database
            SqlConnection myConn;
            myConn = new SqlConnection();
            myConn.ConnectionString = AppConstant.DevConnectionString;
            myConn.Open();

            //SQL query 
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
            // Data row for Question table
            DataRow myRow;
            while (myReader.Read())
            {

                myRow = questionDB.NewRow();
                myRow["Q_ID"] = myReader["Q_ID"].ToString();
                myRow["Q_Text"] = myReader["Q_Text"].ToString();
                myRow["Q_Type"] = myReader["Q_Type"].ToString();
                myRow["Next_Q_ID"] = myReader["Next_Q_ID"].ToString();

                // if (int.Parse((string)myRow["Q_ID"]) == AppSession.getQuestionNumber())

                if (int.Parse((string)myRow["Q_ID"]) == Convert.ToInt32(Session["Q_Num"]))
                {
                    questionText = myRow["Q_Text"].ToString();
                    questionDB.Rows.Add(myRow);


                }

                if (QuestNum == 4)
                {
                    PlaceHolder1.Controls.Add(txtBoxPostCode);
                    txtBoxPostCode.Text = String.Empty;
                }
                else if (QuestNum == 5)
                {
                    PlaceHolder1.Controls.Add(txtBoxEmail);
                    txtBoxEmail.Text = String.Empty;
                }

                dbTableView.DataSource = questionDB;
                dbTableView.DataBind();

            }
            LabQuestion.Text = Session["Q_Num"].ToString() + ". " + questionText;
            myConn.Close();

            myConn.Open();

            SqlCommand Q_OptionCommand;
            Q_OptionCommand = new SqlCommand("SELECT * FROM Question_Options WHERE Q_ID = @id", myConn);
            Q_OptionCommand.Parameters.AddWithValue("@id", QuestNum);

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

                Q_OptionDB.Rows.Add(Q_OptionRow);
                TbQ_OptionView.DataSource = Q_OptionDB;
                TbQ_OptionView.DataBind();

                // depending on the question , the question option show up
                if (QuestNum == 1 || QuestNum == 2 || QuestNum == 6 || QuestNum == 9)
                {
                    RadioButtonList radioBtnList = new RadioButtonList();
                    radioBtnList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));
                    PlaceHolder1.Controls.Add(radioBtnList);

                }

                else if (QuestNum == 3 || QuestNum == 10 || QuestNum == 11)
                {

                    dropDownList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));
                    PlaceHolder1.Controls.Add(dropDownList);
                }
                // else if (QuestNum == 4)
                // {
                //     TextBox txtBoxPostCode = new TextBox();
                //     PlaceHolder1.Controls.Add(txtBoxPostCode);
                //     txtBoxPostCode.Text = String.Empty;
                // }
                else if (QuestNum == 5)
                {

                    PlaceHolder1.Controls.Add(txtBoxEmail);
                    txtBoxEmail.Text = String.Empty;
                }
                else if (QuestNum == 7 || QuestNum == 8 || QuestNum == 12)
                {
                    CheckBoxList checkBoxList = new CheckBoxList();
                    checkBoxList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));

                    PlaceHolder1.Controls.Add(checkBoxList);

                }



            }

            myConn.Close();
            // Post back error handle
            //if (!IsPostBack)
            //LabQuestion.Text = AppSession.getQuestionNumber() + ". " + questionText;

        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // The session holding the question number

            // AppSession.setQuestionNumber(AppSession.getQuestionNumber() + 1);
            //LabQuestion.Text = AppSession.getQuestionNumber() + ". " + questionText;
            Session["Q_Num"] = Convert.ToInt32(Session["Q_Num"]) + 1;
            Response.Redirect("Questions.aspx");

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