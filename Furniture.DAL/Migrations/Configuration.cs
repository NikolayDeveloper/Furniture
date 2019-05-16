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
                List<Room> rooms = new List<Room>() { new Room {Name="�������" },
                                                    new Room {Name="�����" } };

                List<Stuff> stuffs = new List<Stuff>() { new Stuff { Name = "����", IdRoom = 1 },
                                                    new Stuff { Name = "�������", IdRoom = 1 },
                                                     new Stuff { Name = "��������", IdRoom = 1 },
                                                    new Stuff { Name = "����", IdRoom = 2 },
                                                    new Stuff { Name = "����������", IdRoom = 2 },
                                                    new Stuff { Name = "��������", IdRoom = 2 }};
                List<FurnitureList> furniture = new List<FurnitureList>() {
                    new FurnitureList {Photo=null,Name="Labundu",Material="������",Characteristic="�� �������",IsExist=true,Price=20000,IdStuff=1 } };
            
           // context.Rooms.AddRange(rooms);
               // context.Stuffs.AddRange(stuffs);
            context.FurnitureLists.AddRange(furniture);
                context.SaveChanges();
          //  }
        }
    }
}
