namespace BirdWatchersWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Location", "ClosestCity", c => c.String(nullable: false));
            AddColumn("dbo.Location", "North", c => c.Double(nullable: false));
            AddColumn("dbo.Location", "East", c => c.Double(nullable: false));
            AddColumn("dbo.Location", "South", c => c.Double(nullable: false));
            AddColumn("dbo.Location", "West", c => c.Double(nullable: false));
            AddColumn("dbo.Sighting", "TimeSeen", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sighting", "TimeSeen");
            DropColumn("dbo.Location", "West");
            DropColumn("dbo.Location", "South");
            DropColumn("dbo.Location", "East");
            DropColumn("dbo.Location", "North");
            DropColumn("dbo.Location", "ClosestCity");
            DropColumn("dbo.Location", "Name");
        }
    }
}
