using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Domain.Repositories
{
    public static class DishRepository
    {
        private static List<Dish> _dishesContext = new List<Dish>()
        {
            new Dish {Id = 1, Name = "eggs", TimeOfDay = TimeOfDay.Morning},
            new Dish {Id = 2, Name = "Toast", TimeOfDay = TimeOfDay.Morning},
            new Dish {Id = 3, Name = "coffee", TimeOfDay = TimeOfDay.Morning},

            new Dish {Id = 1, Name = "steak", TimeOfDay = TimeOfDay.Night},
            new Dish {Id = 2, Name = "potato", TimeOfDay = TimeOfDay.Night},
            new Dish {Id = 3, Name = "wine", TimeOfDay = TimeOfDay.Night},
            new Dish {Id = 4, Name = "cake", TimeOfDay = TimeOfDay.Night}
        };

        public static List<Dish> DishesContext
        {
            get { return _dishesContext; }
            set { _dishesContext = value; }
        }

        public static List<Dish> GetByIsdAndTimeOfDay(int[] ids, TimeOfDay timeOfDay)
        {
            var dish = _dishesContext.Where(x =>  ids.Contains(x.Id)  &&
                                               x.TimeOfDay == timeOfDay).ToList();

            return dish;
        }

    }
}
