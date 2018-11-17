using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Calculator.Core;

namespace Calculator.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Calculator Pratical Exercise!");
            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("Please type in the string");
            Console.WriteLine("(type /q or /quit to finish input and press enter to insert \\n)");
            string numbers = string.Empty;
            StringCalculator calcStr = new StringCalculator();
            while (true)
            {
                string cmd = Console.ReadLine();
                if(cmd.ToLower().Equals("/q",StringComparison.OrdinalIgnoreCase) || cmd.ToLower().Equals("/quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                numbers += cmd + "\n";
            }
            var sum = calcStr.Add(numbers);
            try
            {
                Console.WriteLine($"result: {sum}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong:\n {ex.Message}");
            }
            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
