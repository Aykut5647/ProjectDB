using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    internal class DishesContext:DbContext
    {
        public DishesContext() : base("DishesContext")
        {

        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
    }
}
