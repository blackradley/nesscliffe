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
                        MonthTime = c.DateTime(nullable: false),
                        MarketingSpend = c.Int(nullable: false),
                        RegionalTv = c.Boolean(nullable: false),
                        NationalTv = c.Boolean(nullable: false),
                        OverseasTv = c.Boolean(nullable: false),
                        WebsiteUrl = c.String(),
                        WebsiteVisitors = c.Int(nullable: false),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                        FlickrUrl = c.String(),
                        InstagramUrl = c.String(),
                        YoutubeUrl = c.String(),
                        VimeoUrl = c.String(),
                        PinterestUrl = c.String(),
                        HoursMonday = c.Int(nullable: false),
                        HoursTuesday = c.Int(nullable: false),
                        HoursWednesday = c.Int(nullable: false),
                        HoursThursday = c.Int(nullable: false),
                        HoursFriday = c.Int(nullable: false),
                        HoursSaturday = c.Int(nullable: false),
                        HoursSunday = c.Int(nullable: false),
                        Visitors = c.Int(nullable: false),
                        Site_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.Site_Id)
                .Index(t => t.Site_Id);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner = c.String(),
                        Name = c.String(),
                        Postcode = c.String(),
                        Museum = c.Boolean(nullable: false),
                        Castle = c.Boolean(nullable: false),
                        Gallery = c.Boolean(nullable: false),
                        WorldHeritageSite = c.Boolean(nullable: false),
                        HistoricHouse = c.Boolean(nullable: false),
                        HistoricSite = c.Boolean(nullable: false),
                        OpenAir = c.Boolean(nullable: false),
                        Accreditation = c.Boolean(nullable: false),
                        AreaIndoor = c.Int(nullable: false),
                        AreaOutdoor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Months", "Site_Id", "dbo.Sites");
            DropIndex("dbo.Months", new[] { "Site_Id" });
            DropTable("dbo.Sites");
            DropTable("dbo.Months");
        }
    }
}
