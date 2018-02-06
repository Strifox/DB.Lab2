namespace DB.Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMapNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Maps", "map_name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Maps", "map_name", c => c.String(maxLength: 250));
        }
    }
}
