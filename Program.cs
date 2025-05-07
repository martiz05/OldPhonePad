using OldPhonePad.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConsoleHelper consoleHelper = new ConsoleHelper();
                var decoderService = new DecoderService();

                string input = consoleHelper.PrintInput("Please enter the string: ");
                string decodedString = decoderService.DecodeInput(input);
                consoleHelper.PrintInput(decodedString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        

        }

    }


    public class ConsoleHelper
    {       

        public string PrintInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void PrintErrors(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {message}");
            Console.ResetColor();
        }

    }
}
