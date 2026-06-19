using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FoodDelivery.Controller
{
    internal class DishesController
    {
        private DishesContext context = new DishesContext();

        public List<Dish> GetDishes()
        {
            return context.Dishes
                .Include(x => x.DishTypes)
                .ToList();
        }

        public List<DishType> GetDishTypes()
        {
            return context.DishTypes.ToList();
        }

        public void Add(Dish dish)
        {
            context.Dishes.Add(dish);
            context.SaveChanges();
        }

        public void Update(Dish dish)
        {
            var current = context.Dishes.Find(dish.Id);

            if (current != null)
            {
                current.Name = dish.Name;
                current.Description = dish.Description;
                current.Price = dish.Price;
                current.Grammage = dish.Grammage;
                current.DishTypeId = dish.DishTypeId;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dish = context.Dishes.Find(id);

            if (dish != null)
            {
                context.Dishes.Remove(dish);
                context.SaveChanges();
            }
        }
    }
}
