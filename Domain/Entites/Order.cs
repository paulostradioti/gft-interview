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
        public List<Dish> Selections;
        public TimeOfDay TimeOfDay;
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
            TimeOfDay = timeOfDay.ConvertToTimeOfDay();
        }

        public void GetDishes()
        {

            var dishesIds = UserInputParser.ExtractDishesIds(_orderInputText);

            bool breakLoop = false;
            for (var i = 0; i < dishesIds.Length && !breakLoop; i++)
            {
                var dish = DishRepository.GetByIdAndTimeOfDay(dishesIds[i], TimeOfDay);
                Selections.Add(dish);

                if (dish == null)
                    breakLoop = true;
            }
        }

        public override string ToString()
        {

            var selections = Selections.Where(x => x != null).GroupBy(x => new {Id = x.Id, Name = x.Name}) //Group by Id and Name
                .Select(p => new
                {
                    Id = p.Key.Id,
                    Name = p.Key.Name,
                    Count = p.Count()
                })
                .OrderBy(x => x.Id); //Orders by Id (wich corresponts to the order entree, side, drink and dessert)

            List<string> outputBuffer = new List<string>();
            
            string stringTimeOfDay = ((TimeOfDay)TimeOfDay).ToString();
            outputBuffer.Add(stringTimeOfDay);

            var selectionItems = selections.ToList().Select(x => new
            {
                //creates the text like cofee(x3)
                Text = String.Format("{0}{1}", x.Name, (x.Count > 1 ? "" : String.Format("(x{0})", x.Count))).ToString()
            }).Select(x => x.ToString()).ToArray();

            outputBuffer.AddRange(selectionItems);
            


            return String.Join(", ", outputBuffer);
        }
    }
}
