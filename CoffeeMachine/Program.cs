using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            const double AmericanoPrice = 15.0;
            const double CapuchinoPrice = 20.0;
            const double EspressoPrice = 10.0;
            const double LatePrice = 25.0;


            const double StandartCupMult = 1;
            const double MediumCupMult = 1.2;
            const double BigCupMult = 1.5;


            Console.WriteLine("Coffee drinks");
            Console.WriteLine("*******************");
            Console.WriteLine("1 - Americano");
            Console.WriteLine("2 - Capuchino");
            Console.WriteLine("3 - Espresso");
            Console.WriteLine("4 - Late");

            double cost = 0.0;
            bool errorInput = false;

            Console.Write("Select the drink please: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    cost = AmericanoPrice;
                    break;
                case "2":
                    cost = LatePrice;
                    break;
                case "3":
                    cost = CapuchinoPrice;
                    break;
                case "4":
                    cost = EspressoPrice;
                    break;

                default:
                    errorInput = true;
                    //goto case "1";
                    break;
            }

            if (errorInput == false)
            {
                double standartCapPrice = cost * StandartCupMult;
                double mediumCapPrice = cost * MediumCupMult;
                double bigCapPrice = cost * BigCupMult;

                Console.WriteLine("Cap size");
                Console.WriteLine($"1 - standart 200ml ({standartCapPrice:C})");
                Console.WriteLine($"2 - medium 250ml   ({mediumCapPrice:C})");
                Console.WriteLine($"3 - big 300ml   ({bigCapPrice:C})");

                Console.Write("Please enter your selection: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": cost = standartCapPrice; break;
                    case "2": cost = mediumCapPrice; break;
                    case "3": cost = bigCapPrice; break;
                    default: errorInput = true; break;
                }

                if (errorInput == false)
                {
                    Console.WriteLine($"To pay: {cost:C}");
                    Console.Write("Deposit money: ");
                    double inputMoney = Double.Parse(Console.ReadLine());

                    if (inputMoney >= cost)
                    {
                        double delivery = Math.Round(inputMoney - cost, 2);

                        string message = (delivery > 0.0)
                            ? $"Your change: {delivery:C}"
                            : "Change not required";

                        Console.WriteLine(message);
                        Console.WriteLine("Thank you and goodbye.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds, the order is canceled.");
                    }
                }
            }

            if (errorInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input");
            }

            Console.ReadLine();
        }
    }
}
