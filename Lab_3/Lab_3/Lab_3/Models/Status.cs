using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_3.Models
{
    public class Status
    {
        public int Code { get; set; }
        public int Part { get; set; }
        public string Message { get; set; }

        public Status ()
        {
            Code = 0;
            Part = 0;
            Message = null;
        }

        public Status (int code, int part, string message)
        {
            Code = code;
            Part = part;
            Message = message;
        }
    }
}