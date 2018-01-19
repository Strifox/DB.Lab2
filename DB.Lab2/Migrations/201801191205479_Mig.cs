namespace DB.Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Max_Moves = c.Int(nullable: false),
                        Map_Name = c.String(maxLength: 250),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player_Score = c.Int(nullable: false),
                        Map_Id = c.Int(nullable: false),
                        Player_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.Map_Id, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .Index(t => t.Map_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Moves = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Maps", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Scores", "Map_Id", "dbo.Maps");
            DropIndex("dbo.Scores", new[] { "Player_Id" });
            DropIndex("dbo.Scores", new[] { "Map_Id" });
            DropIndex("dbo.Maps", new[] { "Player_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Scores");
            DropTable("dbo.Maps");
        }
    }
}
