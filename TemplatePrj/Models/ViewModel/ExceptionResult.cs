using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePrj.Models.ViewModel
{
    public class ExceptionResult
    {
        public ExceptionResult(string message, int statusCode)
        {
            this.Message = message;
            this.StatusCode = statusCode;
        }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
