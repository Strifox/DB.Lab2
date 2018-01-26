namespace DB.Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Moves", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Moves", c => c.Int());
        }
    }
}
