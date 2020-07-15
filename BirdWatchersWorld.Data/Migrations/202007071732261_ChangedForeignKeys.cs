namespace BirdWatchersWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bird",
                c => new
                    {
                        BirdID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MainColor = c.String(nullable: false),
                        SecondColor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BirdID);
            
            CreateTable(
                "dbo.Sighting",
                c => new
                    {
                        SightingID = c.Int(nullable: false, identity: true),
                        TimeSeen = c.DateTimeOffset(nullable: false, precision: 7),
                        SpotterID = c.String(maxLength: 128),
                        BirdID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SightingID)
                .ForeignKey("dbo.Bird", t => t.BirdID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.SpotterID)
                .Index(t => t.SpotterID)
                .Index(t => t.BirdID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ClosestCity = c.String(nullable: false),
                        North = c.Double(nullable: false),
                        East = c.Double(nullable: false),
                        South = c.Double(nullable: false),
                        West = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Sighting", "SpotterID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Sighting", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Sighting", "BirdID", "dbo.Bird");
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Sighting", new[] { "LocationID" });
            DropIndex("dbo.Sighting", new[] { "BirdID" });
            DropIndex("dbo.Sighting", new[] { "SpotterID" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Location");
            DropTable("dbo.Sighting");
            DropTable("dbo.Bird");
        }
    }
}
