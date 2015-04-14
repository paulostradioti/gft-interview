using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;
using Domain.Exceptions;

namespace Domain.Utilities
{
    public class UserInputParser
    {
        /// <summary>
        /// Returns the Time of Day (first parameter of the input)
        /// </summary>
        /// <returns></returns>
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

        public static int[] ExtractDishesIds(string userInput)
        {
            List<int> parsedInts = new List<int>();

            var inputEntries = userInput.Split(',').Skip(1).ToArray();
            if (inputEntries == null || inputEntries.Length == 0)
            {
                throw new InvalidSelectionException();
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
