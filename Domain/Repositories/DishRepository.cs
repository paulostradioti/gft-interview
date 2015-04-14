using System.Collections.Generic;
using System.Linq;
using Domain.Entites;

namespace Domain.Repositories
{
    /// <summary>
    /// This class emulates a Dish repository.
    /// </summary>
    public static class DishRepository
    {
        private static List<Dish> _dishesContext = new List<Dish>
        {
            
            new Dish (1,"eggs", DishType.Entree, TimeOfDay.Morning, false),
            new Dish (2,"Toast", DishType.Side, TimeOfDay.Morning, false),
            new Dish (3,"coffee", DishType.Drink, TimeOfDay.Morning, true),
            
            new Dish (1,"steak", DishType.Entree, TimeOfDay.Night, false),
            new Dish (2,"potato", DishType.Drink, TimeOfDay.Night, true),
            new Dish (3,"wine", DishType.Side, TimeOfDay.Night , false),
            new Dish (4,"cake", DishType.Dessert, TimeOfDay.Night, false)

        };

        public static List<Dish> DishesContext
        {
            get { return _dishesContext; }
            set { _dishesContext = value; }
        }

        /// <summary>
        /// Returns the Dish by a pair of id and time of day.
        /// </summary>
        /// <param name="id">The dish id</param>
        /// <param name="timeOfDay">The Time of the Day in wich the dish can be chosen</param>
        /// <returns></returns>
        public static Dish GetByIdAndTimeOfDay(int id, TimeOfDay timeOfDay)
        {
            var dish = _dishesContext.FirstOrDefault(x => x.Id == id &&
                                                          x.TimeOfDay == timeOfDay);

            return dish;
        }
        
    }
}
