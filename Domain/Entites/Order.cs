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

        public void ProcessOrder()
        {
            GetTimeOfDay();
            GetDishes();
        }

        public void GetTimeOfDay()
        {
            var timeOfDay = UserInputParser.ExtractTimeOfDay(_orderInputText);
            _timeOfDay = timeOfDay.ConvertToTimeOfDay();
        }

        public void GetDishes()
        {

            var dishesIds = UserInputParser.ExtractDishesIds(_orderInputText);

            bool breakLoop = false;
            for (var i = 0; i < dishesIds.Length && !breakLoop; i++)
            {
                var dish = DishRepository.GetByIdAndTimeOfDay(dishesIds[i], _timeOfDay);
                dish = CheckSelectionConstraints(dish);

                Selections.Add(dish);

                // if the dish id was not found in the 'database', add a null object, so the system
                //  will be aware tp print out the 'error' message in the output and stop parsing the input.
                if (dish == null)
                    breakLoop = true;
            }
        }

        public Dish CheckSelectionConstraints(Dish dish)
        {

            if (Selections.Any(x => dish != null &&
                                    x.Name == dish.Name &&
                                   !x.CanOrderMultiple))
            {
                return null;
            }


            return dish;
        }

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
