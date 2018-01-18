namespace DB.Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Maps", name: "MapName", newName: "Map_Name");
            AddColumn("dbo.Maps", "Max_Moves", c => c.Int(nullable: false));
            AddColumn("dbo.Maps", "Player_Id", c => c.Int());
            AddColumn("dbo.Scores", "Player_Score", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "Map_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "Player_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Maps", "Map_Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Players", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Maps", "Player_Id");
            CreateIndex("dbo.Scores", "Map_Id");
            CreateIndex("dbo.Scores", "Player_Id");
            AddForeignKey("dbo.Scores", "Map_Id", "dbo.Maps", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Maps", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Scores", "Player_Id", "dbo.Players", "Id", cascadeDelete: true);
            DropColumn("dbo.Maps", "Moves");
            DropColumn("dbo.Scores", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Maps", "Moves", c => c.Int(nullable: false));
            DropForeignKey("dbo.Scores", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Maps", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Scores", "Map_Id", "dbo.Maps");
            DropIndex("dbo.Scores", new[] { "Player_Id" });
            DropIndex("dbo.Scores", new[] { "Map_Id" });
            DropIndex("dbo.Maps", new[] { "Player_Id" });
            AlterColumn("dbo.Players", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.Maps", "Map_Name", c => c.String(maxLength: 4000));
            DropColumn("dbo.Scores", "Player_Id");
            DropColumn("dbo.Scores", "Map_Id");
            DropColumn("dbo.Scores", "Player_Score");
            DropColumn("dbo.Maps", "Player_Id");
            DropColumn("dbo.Maps", "Max_Moves");
            RenameColumn(table: "dbo.Maps", name: "Map_Name", newName: "MapName");
        }
    }
}
