using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Models;

namespace CalculatorApp
{
    internal class Helpers
    {
        internal static List<Calculations> Calculations = new();

        internal static void Calculate(string expression)
        {
            // Parse the expression into tokens
            string[] tokens = expression.Split(' ');

            while (!IsExpressionValid(tokens))
            {
                Console.WriteLine("Please enter a valid expression!");
                Console.Write("Enter expression: ");
                expression = Console.ReadLine();
                tokens = expression.Split(' ');
            }

            var calc_engine = new CalculatorEngine();

            foreach (string token in tokens)
            {
                //Console.WriteLine($"Token: {token}");

                if (double.TryParse(token, out double number))
                {
                    calc_engine.PushNumber(number);
                }

                else
                {
                    calc_engine.PushOperation(token);
                }
            }

            calc_engine.Evaluate();

            Helpers.AddCalculation(calc_engine.Result, expression);
            Console.WriteLine("Press ENTER to return to menu");
            Console.ReadLine();

        }

        private static bool IsExpressionValid(string[] tokens)
        {
            // Check if the expression is valid
            if (tokens.Length % 2 == 0)
            {
                Console.WriteLine("Invalid expression: Missing operation");
                return false;
            }
            if (tokens.Length < 3)
            {
                Console.WriteLine("Invalid expression: Not enough tokens");
                return false;
            }
            return true;
        }

        internal static void AddCalculation(double? res, string exp)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            Calculations.Add(new Calculations
            {
                Result = res,
                Expression = exp,
                Date = date
            });
        }
    }
}
