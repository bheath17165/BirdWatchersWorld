namespace BirdWatchersWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedICollectionAndForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sighting", "SpotterID", c => c.Int(nullable: false));
            AddColumn("dbo.Sighting", "BirdID", c => c.Int(nullable: false));
            AddColumn("dbo.Sighting", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sighting", "SpotterID");
            CreateIndex("dbo.Sighting", "BirdID");
            CreateIndex("dbo.Sighting", "LocationID");
            AddForeignKey("dbo.Sighting", "BirdID", "dbo.Bird", "BirdID", cascadeDelete: true);
            AddForeignKey("dbo.Sighting", "LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
            AddForeignKey("dbo.Sighting", "SpotterID", "dbo.Spotter", "SpotterID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sighting", "SpotterID", "dbo.Spotter");
            DropForeignKey("dbo.Sighting", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Sighting", "BirdID", "dbo.Bird");
            DropIndex("dbo.Sighting", new[] { "LocationID" });
            DropIndex("dbo.Sighting", new[] { "BirdID" });
            DropIndex("dbo.Sighting", new[] { "SpotterID" });
            DropColumn("dbo.Sighting", "LocationID");
            DropColumn("dbo.Sighting", "BirdID");
            DropColumn("dbo.Sighting", "SpotterID");
        }
    }
}
