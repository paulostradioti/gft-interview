using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Domain.Repositories
{
    public static class DishRepository
    {
        private static List<Dish> _dishesContext = new List<Dish>()
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

        public static List<Dish> GetByIsdAndTimeOfDay(int[] ids, TimeOfDay timeOfDay)
        {
            var dish = _dishesContext.Where(x =>  ids.Contains(x.Id)  &&
                                               x.TimeOfDay == timeOfDay)
                                               .ToList();

            return dish;
        }

        public static Dish GetByIdAndTimeOfDay(int id, TimeOfDay timeOfDay)
        {
            var dish = _dishesContext.FirstOrDefault(x => x.Id == id &&
                                                          x.TimeOfDay == timeOfDay);

            return dish;
        }
        
    }
}
