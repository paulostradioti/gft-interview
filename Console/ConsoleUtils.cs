using System;

namespace ConsoleApp
{
    public static class ConsoleUtils
    {
        public static void PrintDashedLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
        }

        /// <summary>
        /// Prints a text in the center of the console
        /// </summary>
        /// <param name="text">The text that will be dis</param>
        public static void WriteCentered(string text)
        {
            //// Adds another text.Length because Padleft actually extens text.Length until padLengh. 
            ////TODO: Provide better docummentation
            //var margin = (Console.WindowWidth - text.Length - 2)/2;
            //var padLengh = margin + text.Length;
            //Console.WriteLine(text.PadLeft(padLengh));


            var marginLeft = ((Console.WindowWidth - text.Length - 2) / 2);
            var marginRight = Console.WindowWidth - marginLeft - text.Length;

            Console.Write(String.Format("{0}{1}{2}{3}{4}", "|", " ".PadLeft(marginLeft), text, " ".PadLeft(marginLeft), "|"));
        }
    }
}