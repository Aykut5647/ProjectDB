namespace FoodDelivery.Migrations
{
    using FoodDelivery.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodDelivery.Model.DishesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodDelivery.Model.DishesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            if (!context.DishTypes.Any())
            {
                context.DishTypes.AddOrUpdate(
                    x => x.TypeName,
                    new DishType { TypeName = "Предястие" },
                    new DishType { TypeName = "Основно" },
                    new DishType { TypeName = "Супи" },
                    new DishType { TypeName = "Десерти" },
                    new DishType { TypeName = "Аламинути" }
                );

                context.SaveChanges();
            }
        }
    }
}
