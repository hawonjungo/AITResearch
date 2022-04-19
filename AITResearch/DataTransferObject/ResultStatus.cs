using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITResearch.DataTransferObject
{
    public class ResultStatus
    {
        private int resultStatusCode;
        private string message;

        public int ResultStatusCode { get => resultStatusCode; set => resultStatusCode = value; }
        public string Message { get => message; set => message = value; }
    }
}