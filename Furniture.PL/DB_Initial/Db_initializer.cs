using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Furniture.DAL;
namespace Furniture.PL
{
    /// <summary>
    /// Инициализация базы данных
    /// </summary>
    public class Db_initializer: DropCreateDatabaseIfModelChanges<FurnitureContext>
    {
        protected override void Seed(FurnitureContext context)
        {
            List<Room> rooms = new List<Room>() { new Room {Name="Спальня" },
                                                    new Room {Name="Кухня" } };

            List<Stuff> stuffs = new List<Stuff>() { new Stuff { Name = "Шкаф", IdRoom = 1 },
                                                    new Stuff { Name = "Кровать", IdRoom = 1 },
                                                     new Stuff { Name = "Тумбочка", IdRoom = 1 },
                                                    new Stuff { Name = "Стол", IdRoom = 2 },
                                                    new Stuff { Name = "Столешница", IdRoom = 2 },
                                                    new Stuff { Name = "Гарнитур", IdRoom = 2 }};
           
            context.Rooms.AddRange(rooms);
            context.Stuffs.AddRange(stuffs);
            context.SaveChanges();
        }
    }
}