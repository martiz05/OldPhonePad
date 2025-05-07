using OldPhonePad.Helpers;
using OldPhonePad.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad.Services
{
    public class DecoderService
    {
        private readonly Decoder _decoder;
        private readonly DecoderValidator _validator;
        private readonly KeypadHelper _keypadHelper;

        public DecoderService()
        {
            _keypadHelper = new KeypadHelper();
            _decoder = new Decoder(_keypadHelper);
            _validator = new DecoderValidator(_keypadHelper);
        }

        public string DecodeInput(string input)
        {
            var validationResult = _validator.Validate(input);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.GetErrors());
            }

            return _decoder.Decode(input);
        }

    }
}
