using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    public class DishType
    {
        public int Id { get; set; } //PK
        public string TypeName { get; set; }

        // 1 : M Връзка
        public ICollection<Dish> Dishes { get; set; } 
    }
}
