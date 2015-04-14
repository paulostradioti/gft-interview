using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;
using Domain.Utilities;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loop until the user presses Ctrl + C
            do
            {
                ShowApplicationHeader();

                try
                {
                    var userInput = Console.ReadLine();
                    var order = new Order(userInput);

                    Console.WriteLine(order.TimeOfDay);
                    Console.WriteLine(order.Selections.ToString());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.DetailedExceptionMessage());
                }


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        private static void ShowApplicationHeader()
        {
            ConsoleUtils.PrintDashedLine();

            ConsoleUtils.WriteCentered("Please make your selection");

            ConsoleUtils.PrintDashedLine();
        }

    }
}
