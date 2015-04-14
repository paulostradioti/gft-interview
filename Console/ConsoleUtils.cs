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
          
            var marginLeft = ((Console.WindowWidth - text.Length - 2) / 2) - 2;
            var marginRight = Console.WindowWidth - marginLeft - text.Length - 2;

            Console.Write(String.Format("{0}{1}{2}{3}{4}", "|", new String(' ', marginLeft), text, new String(' ', marginRight), "|"));
        }
    }
}