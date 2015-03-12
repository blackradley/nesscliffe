namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SiteId = c.Guid(nullable: false),
                        MonthTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MarketingEffort = c.Int(),
                        WebsiteVisitors = c.Int(),
                        RegionalTv = c.Boolean(nullable: false),
                        NationalTv = c.Boolean(nullable: false),
                        OverseasTv = c.Boolean(nullable: false),
                        RegionalRadio = c.Boolean(nullable: false),
                        NationalRadio = c.Boolean(nullable: false),
                        RegionalNewsPaper = c.Boolean(nullable: false),
                        NationalNewsPaper = c.Boolean(nullable: false),
                        WebsiteUrl = c.String(),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                        YoutubeUrl = c.String(),
                        VisitorsGeneral = c.Int(),
                        VisitorsMember = c.Int(),
                        VisitorsSchool = c.Int(),
                        IncomeAdmissions = c.Int(),
                        VisitorsPercentNoFamily = c.Int(nullable: false),
                        VisitorsPercentFamily = c.Int(nullable: false),
                        VisitorsPercentChildren = c.Int(nullable: false),
                        VisitorsPercentAdult = c.Int(nullable: false),
                        VisitorsPercentRetired = c.Int(nullable: false),
                        HoursMonday = c.Single(nullable: false),
                        HoursTuesday = c.Single(nullable: false),
                        HoursWednesday = c.Single(nullable: false),
                        HoursThursday = c.Single(nullable: false),
                        HoursFriday = c.Single(nullable: false),
                        HoursSaturday = c.Single(nullable: false),
                        HoursSunday = c.Single(nullable: false),
                        IsRetail = c.Boolean(),
                        IncomeRetail = c.Int(),
                        PayToShop = c.Boolean(nullable: false),
                        ShopVisibleFromEntrance = c.Boolean(nullable: false),
                        ExitViaShop = c.Boolean(nullable: false),
                        DistanceToShop = c.Int(),
                        DistanceToShopUnits = c.Int(nullable: false),
                        AreaShop = c.Int(),
                        AreaShopUnits = c.Int(nullable: false),
                        NumberProducts = c.Int(),
                        PercentageRelatedProducts = c.Int(),
                        IsRefreshment = c.Boolean(),
                        IncomeRefreshment = c.Int(),
                        PayToRefreshment = c.Boolean(nullable: false),
                        RefreshmentVisibleFromEntrance = c.Boolean(nullable: false),
                        DistanceToRefreshment = c.Int(),
                        DistanceToRefreshmentUnits = c.Int(nullable: false),
                        NumberSeatsIndoors = c.Int(),
                        NumberSeatsOutside = c.Int(),
                        IsVending = c.Boolean(nullable: false),
                        IsCafeteria = c.Boolean(nullable: false),
                        IsTableService = c.Boolean(nullable: false),
                        IsRefreshmentOutsideHours = c.Boolean(nullable: false),
                        IsTeaAndCoffee = c.Boolean(nullable: false),
                        IsCakeAndBiscuit = c.Boolean(nullable: false),
                        IsLightMeals = c.Boolean(nullable: false),
                        IsFullMeal = c.Boolean(nullable: false),
                        IsOrganic = c.Boolean(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        IsGlutenFree = c.Boolean(nullable: false),
                        IsAlcohol = c.Boolean(nullable: false),
                        IsCateringInHouse = c.Boolean(nullable: false),
                        IsCateringOutToLocalAuthority = c.Boolean(nullable: false),
                        IsCateringOutToCompany = c.Boolean(nullable: false),
                        IsDonationOpportunity = c.Boolean(),
                        IncomeDonation = c.Int(),
                        DistanceToDonation = c.Int(),
                        DistanceToDonationUnits = c.Int(nullable: false),
                        NumberDonationOpportunities = c.Int(),
                        IsAdditionalEvents = c.Boolean(),
                        NumberAdditionalEvents = c.Int(),
                        NumberVisitorsAdditional = c.Int(),
                        IncomeAdditionalEvents = c.Int(),
                        NumberArtefacts = c.Int(),
                        ArtefactsDisplay = c.Int(),
                        IsCollectionsOutstanding = c.Boolean(nullable: false),
                        NumberCollectionsOutstanding = c.Int(),
                        ProgrammeMassAppeal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        IsMuseum = c.Boolean(nullable: false),
                        IsAccredited = c.Boolean(nullable: false),
                        IsCastle = c.Boolean(nullable: false),
                        IsHistoricHouse = c.Boolean(nullable: false),
                        IsArtsCentre = c.Boolean(nullable: false),
                        IsGallery = c.Boolean(nullable: false),
                        IsWorldHeritageSite = c.Boolean(nullable: false),
                        IsOpenAir = c.Boolean(nullable: false),
                        IsHeritageSite = c.Boolean(nullable: false),
                        IsNationalTrust = c.Boolean(nullable: false),
                        IsPark = c.Boolean(nullable: false),
                        IsNatureReserve = c.Boolean(nullable: false),
                        AreaIndoor = c.Int(nullable: false),
                        AreaIndoorUnits = c.Int(nullable: false),
                        AreaOutdoor = c.Single(nullable: false),
                        AreaOutdoorUnits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Sites", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Months", "SiteId", "dbo.Sites");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sites", new[] { "UserId" });
            DropIndex("dbo.Months", new[] { "SiteId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sites");
            DropTable("dbo.Months");
        }
    }
}
