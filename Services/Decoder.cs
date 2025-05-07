using OldPhonePad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad.Services
{
    /// <summary>
    /// Decoder class that decodes the input string based on the old phone keypad layout.
    /// </summary>
    public class Decoder
    {
        private readonly KeypadHelper _keypadHelper;
        public Decoder(KeypadHelper keypadHelper)
        {
            _keypadHelper = keypadHelper;
        }

        /// <summary>
        /// Decodes the input string based on the old phone keypad layout.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Decode(string input)
        {
            string output = "";
            char? lastKey = null;
            int count = 0;

            foreach (char c in input)
            {
                if (c == '#')
                {
                    if (lastKey != null)
                        output += GetLetter(lastKey.Value, count);
                    break;
                }

                if (c == ' ')
                {
                    if (lastKey != null)
                    {
                        output += GetLetter(lastKey.Value, count);
                        lastKey = null;
                        count = 0;
                    }
                    continue;
                }

                if (c == '*')
                {
                    lastKey = null;
                    count = 0;
                    continue;
                }

                if (lastKey == c)
                {
                    count++;
                }
                else
                {
                    if (lastKey != null)
                        output += GetLetter(lastKey.Value, count);

                    lastKey = c;
                    count = 1;
                }
            }

            return output;
        }

        private char GetLetter(char key, int count)
        {
            var letters = _keypadHelper.GetLetterFromNumber(key);
            int index = (count - 1) % letters.Length;
            return letters[index];
        }
    }
}
