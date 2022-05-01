using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITResearch.DataTransferObject;
using System.Data.SqlClient;

namespace AITResearch
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            // get data from user input
            String FirstName = TextBoxFirstName.Text;
            String LastName = TextBoxLastName.Text;
            String PhoneNumber = TextBoxPhoneNumber.Text;
            String DOB = TextBoxDOB.Text;
        

            ResultStatus resultStatus = RegisterMember(FirstName, LastName, PhoneNumber, DOB);

            regResult.Text = resultStatus.Message;

            Response.Redirect("Questions.aspx");
        }



        private ResultStatus RegisterMember(String First_Name, String Last_Name, String Phone_Number, String DoB)
        {

            ResultStatus resultStatus = new ResultStatus();

                using (SqlConnection conn = Utils.GetConnection())
                {
                    String query = " INSERT INTO R_Register (First_Name,Last_Name,Phone_Number,DoB) VALUES (@First_Name,@Last_Name,@Phone_Number,@DOB)";
                    conn.Open();
                    // Convert datetime with the split "/"
                    string[] dateTimeParts = DoB.Split('/');
                    int day = Convert.ToInt32(dateTimeParts[0]);
                    int month = Convert.ToInt32(dateTimeParts[1]);
                    int year = Convert.ToInt32(dateTimeParts[2]);
                    DateTime dateOfBirth = new DateTime(year, month, day);

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {                      
                    // save all the data to the database
                        command.Parameters.AddWithValue("@First_Name", First_Name);
                        command.Parameters.AddWithValue("@Last_Name", Last_Name);                   
                        command.Parameters.AddWithValue("@Phone_Number",Phone_Number);
                        command.Parameters.AddWithValue("@DoB", DoB);

                        int result = command.ExecuteNonQuery();

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
                        }
                    }

                }   
            return resultStatus;
        }
    }
}