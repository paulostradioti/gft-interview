using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;

namespace Domain.Utilities
{
    public class UserInputParser
    {
        /// <summary>
        /// Returns the Time of Day (first parameter of the input)
        /// </summary>
        /// <param name="userInput">The user input text</param>
        /// <returns>The Time of the day extracted from the user input</returns>
        public static string ExtractTimeOfDay(string userInput)
        {
            var inputEntries = userInput.Split(',');
            if (inputEntries == null || inputEntries.Length == 0)
            {
                throw new InvalidTimeOfDayException();
            }

            if (!inputEntries[0].IsValidTimeOfDay())
            {
                throw new InvalidTimeOfDayException();
            }

            return inputEntries[0];
        }

        /// <summary>
        /// Returns an array of integers representing the user's selections.
        /// </summary>
        /// <param name="userInput">The user input text</param>
        /// <returns>An array of integers continaing all the ids of the user's selections</returns>
        /// <exception cref="Domain.Exceptions.InvalidInputException">Thrown when the user inserts a non numerical character in the selection list</exception>
        public static int[] ExtractDishesIds(string userInput)
        {
            List<int> parsedInts = new List<int>();

            var inputEntries = userInput.Split(',').Skip(1).ToArray();
            if (inputEntries == null || inputEntries.Length == 0)
            {
                throw new InvalidInputException("You should select at least one option from the menu.");
            }

            foreach (var dishId in inputEntries)
            {
                int parsedInt;
                if (Int32.TryParse(dishId, out parsedInt))
                {
                    parsedInts.Add(parsedInt);
                }
                else
                {
                    throw new InvalidInputException(String.Format("The {0} selection in the input is invalid. Please, check your selection and try again.", dishId));
                }
            }

            return parsedInts.ToArray();
        }
    }
}
