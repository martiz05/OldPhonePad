using System.Collections.Generic;

namespace OldPhonePad.Helpers
{
    public class KeypadHelper
    {
        private readonly Dictionary<char, string> _keypad = new Dictionary<char, string>()
        {
            { '1', "&'(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        public string GetLetterFromNumber(char number) =>
                        _keypad.ContainsKey(number) ? _keypad[number] : string.Empty;
    }
}
