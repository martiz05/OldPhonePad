using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad.Validators
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;

        public List<ValidationError> Errors;

        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }

        public void AddError(string message)
        {
            Errors.Add(new ValidationError(message));
        }


        public string GetErrors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in Errors)
            {
                sb.AppendLine(error.Message);
            }
            return sb.ToString();
        }
    }
}
