namespace Furniture.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stuffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IdRoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.IdRoom, cascadeDelete: true)
                .Index(t => t.IdRoom);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuffs", "IdRoom", "dbo.Rooms");
            DropIndex("dbo.Stuffs", new[] { "IdRoom" });
            DropTable("dbo.Stuffs");
            DropTable("dbo.Rooms");
        }
    }
}
