using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    /// <summary>
    /// This class represents a dish that the user can choose in the options.
    /// </summary>
    public class Dish : BaseEntity
    {
        public Dish(int id, string name, DishType dishType, TimeOfDay timeOfDay, bool canOrderMultiple)
            : base(id, name)
        {
            DishType = dishType;
            TimeOfDay = timeOfDay;
            CanOrderMultiple = canOrderMultiple;
        }

        public TimeOfDay TimeOfDay { get; private set; }
        public DishType DishType { get; private set; }
        public bool CanOrderMultiple { get; private set; }

    }
}
