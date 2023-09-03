using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Errors
{
    public class ErrorVM
    {

        public List<string> Error { get; set; } = new List<string>();
        public short StatusCode { get; set; }

        public ErrorVM()
        {

        }
        public ErrorVM(List<string> errors, short statusCode)
        {
            Error = errors;
            StatusCode = statusCode;
        }
        public ErrorVM(string error, short statusCode)
        {
            Error = new List<string> {  error };
            StatusCode = statusCode;
        }
      
    }
}
