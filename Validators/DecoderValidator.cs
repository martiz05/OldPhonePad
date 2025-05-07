using OldPhonePad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad.Validators
{
    /// <summary>
    /// Class to validate the input string for the decoder.
    /// </summary>
    public class DecoderValidator
    {
        private readonly KeypadHelper _keypadHelper;

        public DecoderValidator(KeypadHelper keypadHelper)
        {
            _keypadHelper = keypadHelper;
        }

        /// <summary>
        /// Method to validate the input string for the decoder.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ValidationResult Validate(string input)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(input))
            {
                result.AddError("Input cannot be empty.");
                return result;
            }

            foreach (char c in input)
            {
                if (!_keypadHelper.GetLetterFromNumber(c).Any() && c != ' ' && c != '#' && c != '*')
                {
                    result.AddError($"Invalid character '{c}' in input.");
                }
            }

            if (input[input.Length - 1] != '#')
            {
                result.AddError("Input must end with '#' character");
            }

            if (input.Count(c => c == '#') > 1)
            {
                result.AddError("Input can only contain one '#' character.");
            }



            return result;
        }
    }
}
