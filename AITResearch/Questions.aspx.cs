using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using AITResearch.DataTransferObject;
using System.Net;

namespace AITResearch
{
    public partial class Questions : System.Web.UI.Page
    {
        // declair data holder
        private int QuestNum = 0;
        private string questionText;
         int nextQuestion = 1;

        private RadioButtonList radioBtnList = new RadioButtonList();
        private DropDownList dropDownList = new DropDownList();
        private CheckBoxList checkBoxList = new CheckBoxList();
        private TextBox txtBoxEmail = new TextBox();
        private TextBox txtBoxPostCode = new TextBox();

        // create next_quest_id holder



        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["R_ID"] == null)
            {
                TestSessionId();
            }

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
                    if (myRow["Next_Q_ID"].ToString() != "")
                    {
                        nextQuestion = Convert.ToInt32(myRow["Next_Q_ID"]);
                    }

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
                    
                    radioBtnList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));
                    PlaceHolder1.Controls.Add(radioBtnList);
                    // use if there because from database the value is NULL and convert to string is became "".
                    if(Q_OptionRow["Next_Q_ID"].ToString() != "")
                    {
                        
                       // nextQuestion = Convert.ToInt32(Q_OptionRow["Next_Q_ID"]);
                    }
                    
                }

                else if (QuestNum == 3 || QuestNum == 10 || QuestNum == 11)
                {

                    dropDownList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));
                    PlaceHolder1.Controls.Add(dropDownList);
                    if (Q_OptionRow["Next_Q_ID"].ToString() != "")
                    {
                      //  nextQuestion = Convert.ToInt32(Q_OptionRow["Next_Q_ID"]);
                    }
                }
                
                else if (QuestNum == 5)
                {

                    PlaceHolder1.Controls.Add(txtBoxEmail);
                    txtBoxEmail.Text = String.Empty;
                    if (Q_OptionRow["Next_Q_ID"].ToString() != "")
                    {
                      //  nextQuestion = Convert.ToInt32(Q_OptionRow["Next_Q_ID"]);
                    }
                }
                else if (QuestNum == 7 || QuestNum == 8 || QuestNum == 12)
                {
                    
                    checkBoxList.Items.Add(new ListItem(Q_OptionRow["Option_Text"].ToString()));
                    PlaceHolder1.Controls.Add(checkBoxList);
                    if (Q_OptionRow["Next_Q_ID"].ToString() != "")
                    {
                       // nextQuestion = Convert.ToInt32(Q_OptionRow["Next_Q_ID"]);
                    }
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

            Session["Q_Num"] = nextQuestion;
            /*if (nextQuestion.Length != 0) { }*/
            if (Convert.ToInt32(Session["Q_Num"]) < 12)
            {
                           

                if (QuestNum == 1 || QuestNum == 2 || QuestNum == 6 || QuestNum == 9)
                {
                    foreach (ListItem item in radioBtnList.Items)
                    {
                        if (item.Selected == true)
                        {
                           
                            SaveData2Database(item.Value);

                            
                        }
                        if (QuestNum == 6 && item.Value == "No")
                        {
                            nextQuestion = Convert.ToInt32(9);
                        }
                        else
                        {
                            nextQuestion = 7;
                        }
                        if (QuestNum == 9 && item.Value == "No")
                        {
                            nextQuestion = 12;
                        }
                    }
                }
                else if (QuestNum == 3 || QuestNum == 10 || QuestNum == 11)
                {
                    foreach (ListItem item in dropDownList.Items)
                    {
                        if (item.Selected == true)
                        {
                            SaveData2Database(item.Value);
                        }
                    }
                }
                else if (QuestNum == 5)
                {
                    SaveData2Database(txtBoxEmail.Text);
                }
                else if (QuestNum == 7 || QuestNum == 8 || QuestNum == 12)
                {
                    foreach (ListItem item in checkBoxList.Items)
                    {
                        if (item.Selected == true)
                        {
                            SaveData2Database(item.Value);
                        }
                    }
                }
                Response.Redirect("Questions.aspx");
            }
            else
            {
                Response.Redirect("Thanks.aspx");
            }

            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Session["Q_Num"]) > 1)
            {
                Session["Q_Num"] = Convert.ToInt32(Session["Q_Num"]) - 1;
                Response.Redirect("Questions.aspx");
            }
            
        }


        private void TestSessionId()
        {

            

            using (SqlConnection conn = Utils.GetConnection())
            {
                String query = "INSERT INTO R_Session (DATE, IP) VALUES (@DATE, @IP) select SCOPE_IDENTITY()";

                conn.Open();

                String dateString = DateTime.Today.ToShortDateString();
                string[] dateTimeParts = dateString.Split('/');
                int day = Convert.ToInt32(dateTimeParts[0]);
                int month = Convert.ToInt32(dateTimeParts[1]);
                int year = Convert.ToInt32(dateTimeParts[2]);

                DateTime date = new DateTime(year, month, day);
                String hostName = Dns.GetHostName();
                String ip = Dns.GetHostByName(hostName).AddressList[0].ToString();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    //command.Parameters.AddWithValue("@R_ID", Session["Respondent_id"]);
                    command.Parameters.AddWithValue("@DATE", date);
                    command.Parameters.AddWithValue("@IP", ip);

                    String id = command.ExecuteScalar().ToString();

                    Session["R_ID"] = id;
                }
                conn.Close();

            }
        }


        private void SaveData2Database(string answer)
        {
            ResultStatus resultStatus = new ResultStatus();

            using (SqlConnection conn = Utils.GetConnection())
            {
                String query = "INSERT INTO R_Answer (R_ID, Q_ID, Answer_Text) VALUES (@R_ID, @Q_ID, @Answer_Text)";

                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@R_ID", Session["R_ID"]);
                    command.Parameters.AddWithValue("@Q_ID", Session["Q_Num"]);
                    command.Parameters.AddWithValue("@Answer_Text", answer);

                    /*int result = command.ExecuteNonQuery();

                    // Error/Success message
                    if (result < 0)
                    {
                        resultStatus.ResultStatusCode = 3;
                        resultStatus.Message = "Error in registration";
                    }
                    else
                    {

                        resultStatus.ResultStatusCode = 1;
                        resultStatus.Message = "Registration succeed";
                    }*/
                }
            }

        }


    }
}