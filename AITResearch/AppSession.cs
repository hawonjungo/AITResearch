using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch
{
    public class AppSession
    {
        // hold the question number

        public static int getQuestionNumber()
        {
            if (HttpContext.Current.Session["QuestionNumber"] == null)
                HttpContext.Current.Session["QuestionNumber"] = 1;
            return (int)HttpContext.Current.Session["QuestionNumber"];
        }

        public static void setQuestionNumber(int _number)
        {
            HttpContext.Current.Session["QuestionNumber"] = _number;
        }
    }
}