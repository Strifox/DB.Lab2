namespace DB.Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContexts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Moves");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Moves", c => c.Int(nullable: false));
        }
    }
}
