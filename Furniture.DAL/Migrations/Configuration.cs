namespace Furniture.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Furniture.DAL.FurnitureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Furniture.DAL.FurnitureContext";
        }

        protected override void Seed(Furniture.DAL.FurnitureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            // context.Stuffs.SqlQuery("DELETE FROM Stuffs");
            // context.Rooms.SqlQuery("DELETE FROM Rooms");
            //if (context.Rooms.Any() != true)
            //{
                List<Room> rooms = new List<Room>() { new Room {Name="Спальня" },
                                                    new Room {Name="Кухня" } };

                List<Stuff> stuffs = new List<Stuff>() { new Stuff { Name = "Шкаф", IdRoom = 1 },
                                                    new Stuff { Name = "Кровать", IdRoom = 1 },
                                                     new Stuff { Name = "Тумбочка", IdRoom = 1 },
                                                    new Stuff { Name = "Стол", IdRoom = 2 },
                                                    new Stuff { Name = "Столешница", IdRoom = 2 },
                                                    new Stuff { Name = "Гарнитур", IdRoom = 2 }};
                List<FurnitureList> furniture = new List<FurnitureList>() {
                    new FurnitureList {Photo=null,Name="Labundu",Material="дерево",Characteristic="Не пылится",IsExist=true,Price=20000,IdStuff=1 } };
            
           // context.Rooms.AddRange(rooms);
               // context.Stuffs.AddRange(stuffs);
            context.FurnitureLists.AddRange(furniture);
                context.SaveChanges();
          //  }
        }
    }
}
