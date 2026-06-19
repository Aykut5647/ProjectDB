using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    public class Dish
    {
        public int Id { get; set; } //PK
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Grammage { get; set; }
        public int DishTypeId { get; set; } //FK
        public DishType DishTypes { get; set; }
    }
}
