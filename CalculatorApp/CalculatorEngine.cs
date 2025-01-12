using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class CalculatorEngine
    {

        internal double? Result { get; set; } = null;

        internal Stack<double> numbers { get; set; } = new Stack<double>();

        internal Stack<string> operations { get; set; } = new Stack<string>();

        internal void PushOperation(string token)
        {
            //Console.WriteLine($"Performing operation: {token}");

            while (operations.Count > 0 && Precendence(token) <= Precendence(operations.Peek()))
            {
                double number1 = numbers.Pop();
                double number2 = numbers.Pop();
                string operation = operations.Pop();
                numbers.Push(PerformOperation(number1, number2, operation));
            }

            operations.Push(token);
        }

        internal void PushNumber(double number)
        {
            //Console.WriteLine($"Pushing number: {number}");
            numbers.Push(number);
        }

        internal void Evaluate()
        {
            while (operations.Count > 0)
            {
                string operation = operations.Pop();
                double number1 = numbers.Pop();
                double number2 = numbers.Pop();
                numbers.Push(PerformOperation(number1, number2, operation));
            }

            Result = numbers.Pop();

            
            Console.WriteLine($"Result: {Result}");
        }

        private int Precendence(string operation)
        {
            switch (operation)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        private double PerformOperation(double number1, double number2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    return number1 / number2;
                default:
                    throw new InvalidOperationException($"Unrecognized operation: {operation}");
            }
        }
    }
}
