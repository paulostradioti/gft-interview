using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;
using Domain.Exceptions;
using Domain.Repositories;

namespace Domain.Utilities
{
    /// <summary>
    /// This class can be used to Parse the user input into Valid System Entities. 
    /// On a user input as follows:
    ///     Input: night, 1, 2, 3
    /// The Entity Methods Should return: 
    ///     night for GetTimeOfDay()
    ///     List of (steak, potato, wine) for GetSelectionList()
    /// </summary>
    public class UserInputParser
    {
        public string UserInput { get; private set; }

        public UserInputParser(string userInput)
        {
            UserInput = userInput;
        }

        public TimeOfDay GetTimeOfDay()
        {
            var inputEntries = UserInput.Split(',');
            if (inputEntries == null || inputEntries.Length == 0)
            {
                throw new InvalidTimeOfDayException();
            }

            TimeOfDay timeOfDay;
            var strTimeOfDay = inputEntries[0];
            if (!Enum.TryParse<TimeOfDay>(strTimeOfDay, true, out timeOfDay))
            {
                throw new InvalidTimeOfDayException();
            }

            return timeOfDay;
        }

        public List<Dish> GetSelectionList()
        {
            var selectionList = new List<Dish>();

            var inputEntries = UserInput.Split(',').Skip(1).Select(int.Parse).ToArray();
            //There must be a Time of Day and a Selection (at least two itens in the array)
            if (inputEntries == null || inputEntries.Length == 0)
            {
                throw new InvalidSelectionException();
            }

            selectionList = DishRepository.GetByIsdAndTimeOfDay(inputEntries, this.GetTimeOfDay());

            return selectionList;
        }

        public override string ToString()
        {
            return UserInput;
        }

        }
}
