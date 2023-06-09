using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validator
{
    public class ValidationObject
    {
        public bool IsValid { get; set; }
        public string Message { get; set; } = "";
        public ValidationObject() { }

        public ValidationObject(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
