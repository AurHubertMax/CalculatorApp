
using CalculatorApp;

Console.WriteLine("-----------------------------------------");
Console.WriteLine("Welcome to the Calculator App");
Console.WriteLine("Enter an expression to calculate, using spaces to separate each token:");
Console.WriteLine("-----------------------------------------\n");
Console.Write("Enter expression: "); string expression = Console.ReadLine();


// Parse the expression into tokens
string[] tokens = expression.Split(' ');

var calc_engine = new CalculatorEngine();

foreach (string token in tokens)
{
    Console.WriteLine($"Token: {token}");

    // need validation checks here

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


