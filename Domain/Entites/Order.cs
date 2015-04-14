using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Utilities;

namespace Domain.Entites
{
    /// <summary>
    /// This class represents an order.
    /// An order is composed by itens selected by the user and and keeps the information about the Time 
    ///     of Day selected by the user. 
    /// </summary>
    public class Order
    {
        public List<Dish> Selections { get; private set; }
        private TimeOfDay _timeOfDay;
        private string _orderInputText;

        public Order(string userInput)
        {
            _orderInputText = userInput;
            Selections = new List<Dish>();

            ProcessOrder();
        }

        /// <summary>
        /// Analyze the user input and set the choosen Time of Day, as well as, fills the Order's 
        ///     Selections with the proper items.
        /// </summary>
        public void ProcessOrder()
        {
            GetTimeOfDay();
            GetDishes();
        }

        /// <summary>
        /// Obtains from the user input the inserted Time of Day
        /// </summary>
        public void GetTimeOfDay()
        {
            var timeOfDay = UserInputParser.ExtractTimeOfDay(_orderInputText);
            _timeOfDay = timeOfDay.ConvertToTimeOfDay();
        }

        /// <summary>
        /// Process the list of Selections and add them to the Order
        /// </summary>
        public void GetDishes()
        {

            var dishesIds = UserInputParser.ExtractDishesIds(_orderInputText);

            bool breakLoop = false;
            for (var i = 0; i < dishesIds.Length && !breakLoop; i++)
            {
                var dish = DishRepository.GetByIdAndTimeOfDay(dishesIds[i], _timeOfDay);
                dish = CheckMultipleOrderConstraint(dish);

                Selections.Add(dish);

                // if the dish id was not found in the 'database', add a null object, so the system
                //  will be aware tp print out the 'error' message in the output and stop parsing the input.
                if (dish == null)
                    breakLoop = true;
            }
        }

        /// <summary>
        /// Checks if that dish can be added multiple times
        /// </summary>
        /// <param name="dish">The dish that should be checked</param>
        /// <returns>Returns the <paramref name="dish"/> parameter if object if the dish is allowed to be 
        /// ordered multiple times. Null otherwise.</returns>
        public Dish CheckMultipleOrderConstraint(Dish dish)
        {

            if (Selections.Any(x => dish != null &&
                                    x.Name == dish.Name &&
                                   !x.CanOrderMultiple))
            {
                return null;
            }

            return dish;
        }

        /// <summary>
        /// This method prints and order to the screen following the format:
        ///     Time of day, entree, side, drink, dessert (when they are available).
        /// </summary>
        /// <returns>a string representing an order.</returns>
        public override string ToString()
        {
            //Group the Selections by Id and Name
            //  ordering them by Id (wich, in our implementation, corresponts to the following order:
            //      entree, side, drink and dessert
            var selections = Selections.Where(x => x != null).GroupBy(x => new {Id = x.Id, Name = x.Name}) 
                .Select(p => new
                {
                    Id = p.Key.Id,
                    Name = p.Key.Name,
                    Count = p.Count()
                })
                .OrderBy(x => x.Id); //

            
            List<string> outputBuffer = new List<string>();
            
            // First thing to go in the Buffer is the Time of Day
            string stringTimeOfDay = ((TimeOfDay)_timeOfDay).ToString();
            outputBuffer.Add(stringTimeOfDay);


            // Then the Selections, grouped by quantity and ordered by type
            selections.ToList().ForEach(x =>
            {
                outputBuffer.Add(String.Format("{0}{1}", x.Name, (x.Count > 1 ? String.Format("(x{0})", x.Count) : "")));
            });


            // Finally, we check if there's a null object in the Selection
            // if there's it's because there's a business rule violation, then, add our final word to the buffer: error.
            if (Selections.Any(x => x == null))
            {
                outputBuffer.Add("error");
            }

            return String.Join(", ", outputBuffer);
        }
    }
}
