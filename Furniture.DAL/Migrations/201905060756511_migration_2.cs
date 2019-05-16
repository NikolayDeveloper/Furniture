namespace Furniture.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FurnitureList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Material = c.String(maxLength: 100),
                        Characteristic = c.String(maxLength: 100),
                        IsExist = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        IdStuff = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stuffs", t => t.IdStuff, cascadeDelete: true)
                .Index(t => t.IdStuff, name: "EX_IdStuff");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FurnitureList", "IdStuff", "dbo.Stuffs");
            DropIndex("dbo.FurnitureList", "EX_IdStuff");
            DropTable("dbo.FurnitureList");
        }
    }
}
