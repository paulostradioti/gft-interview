using System;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Entites;

namespace Domain.Utilities
{
    public static class ExtensionMethos
    {
        /// <summary>
        /// This method goes through all the Inner Exceptions of a given Exception and concatenates their Error message in a sing String that is returned at the end of the loop.
        /// </summary>
        /// <param name="ex">The main exception that might contain a chain of inner exceptions.</param>
        /// <returns></returns>
        public static string DetailedExceptionMessage(this Exception ex)
        {
            var exception = ex;
            var message = new StringBuilder();

            do
            {
                message.AppendLine(exception.Message);
                message.AppendLine(Environment.NewLine);

                exception = ex.InnerException;

            } while (exception != null);

            return message.ToString();
        }

        /// <summary>
        /// Checks if the given string maps to a valid/acceptable Time of Day
        /// </summary>
        /// <param name="text">The string to be checked</param>
        /// <returns>Returns true if the given string can be converted to a Time of Day. False, otherwise.</returns>
        public static bool IsValidTimeOfDay(this string text)
        {
            if (text.IsInteger())
                return false;

            TimeOfDay timeOfDay;
            return Enum.TryParse(text, true, out timeOfDay);
            
        }

        /// <summary>
        /// Creates a TimeOfDay enum from a string.
        /// </summary>
        /// <param name="text">The string to be converted to the Enum</param>
        /// <returns></returns>
        public static TimeOfDay ConvertToTimeOfDay(this string text)
        {
            TimeOfDay timeOfDay;
            Enum.TryParse(text, true, out timeOfDay);

            return timeOfDay;
        }

        /// <summary>
        /// Checks if the given text can be converted to an integer
        /// </summary>
        /// <param name="text">The text to be tested</param>
        /// <returns>True if the string can be casted into an integer, false otherwise.</returns>
        public static bool IsInteger(this string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }
    }
}