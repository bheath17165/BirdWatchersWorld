namespace BirdWatchersWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedLocationIDFromSighting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sighting", "LocationID", "dbo.Location");
            DropIndex("dbo.Sighting", new[] { "LocationID" });
            RenameColumn(table: "dbo.Sighting", name: "LocationID", newName: "Location_LocationID");
            AlterColumn("dbo.Sighting", "Location_LocationID", c => c.Int());
            CreateIndex("dbo.Sighting", "Location_LocationID");
            AddForeignKey("dbo.Sighting", "Location_LocationID", "dbo.Location", "LocationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sighting", "Location_LocationID", "dbo.Location");
            DropIndex("dbo.Sighting", new[] { "Location_LocationID" });
            AlterColumn("dbo.Sighting", "Location_LocationID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Sighting", name: "Location_LocationID", newName: "LocationID");
            CreateIndex("dbo.Sighting", "LocationID");
            AddForeignKey("dbo.Sighting", "LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
        }
    }
}
