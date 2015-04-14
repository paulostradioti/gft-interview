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
                    Console.WriteLine();
                    Console.Write("Input: ");

                    var userInput = Console.ReadLine();
                    var order = new Order(userInput);
                    
                    Console.Write("Output: ");
                    Console.WriteLine(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.DetailedExceptionMessage());
                }

                ShowApplicationFooter();

            } while (true);
        }

        private static void ShowApplicationFooter()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowApplicationHeader()
        {
            ConsoleUtils.PrintDashedLine();

            ConsoleUtils.WriteCentered("Please make your selection (Ctrl + C to exit)");

            ConsoleUtils.PrintDashedLine();
        }

    }
}
