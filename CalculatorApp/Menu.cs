using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Menu
    {
        internal static void DisplayWelcomeMessage()
        {
            bool is_game_on = true;

            
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Welcome to the Calculator App");
                Console.WriteLine("Menu: ");
                Console.WriteLine("V - View past calculations");
                Console.WriteLine("C - Clear past calculations");
                Console.WriteLine("E - Enter expression to calculate");
                Console.WriteLine("Q - Quit the application");
                Console.WriteLine("-----------------------------------------\n");


                Console.Write("Enter an option: ");
                string option = Console.ReadLine();

                switch (option.ToUpper())
                {
                    case "V":
                        Menu.ViewPastCalculations();
                        break;
                    case "C":
                        Helpers.Calculations.Clear();
                        break;
                    case "E":
                        Menu.CalculateMenu();
                        break;
                    case "Q":
                        Console.WriteLine("Quitting the application");
                        is_game_on = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;

                }
            } while (is_game_on);

        }

        private static void ViewPastCalculations()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Past Calculations:");
            foreach(var calc in Helpers.Calculations)
            {
                Console.WriteLine($"{calc.Date} - {calc.Expression} = {calc.Result}");
            }
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Press ENTER to return to menu");
            Console.ReadLine();

        }

        private static void CalculateMenu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter an expression to calculate, using spaces to separate each token:");
            Console.WriteLine("-----------------------------------------\n");
            Console.Write("Enter expression: ");

            string expression = Console.ReadLine();

            Helpers.Calculate(expression);
        }
    }
}
