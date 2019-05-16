namespace Furniture.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FurnitureContext : DbContext
    {
        public FurnitureContext(): base("FurnitureConnection")
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<FurnitureList> FurnitureLists { get; set; }
    }
}