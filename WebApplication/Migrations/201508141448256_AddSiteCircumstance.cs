namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSiteCircumstance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteCircumstances",
                c => new
                    {
                        SiteId = c.Guid(nullable: false),
                        AuthorityDensity = c.Double(nullable: false),
                        WardDensity = c.Double(nullable: false),
                        WardApproximatedSocialGradeAb = c.Int(nullable: false),
                        WardApproximatedSocialGradeC1 = c.Int(nullable: false),
                        WardApproximatedSocialGradeC2 = c.Int(nullable: false),
                        WardApproximatedSocialGradeDe = c.Int(nullable: false),
                        GooglePlaceId = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        GoogleRating = c.Double(),
                    })
                .PrimaryKey(t => t.SiteId)
                .ForeignKey("dbo.Sites", t => t.SiteId)
                .Index(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiteCircumstances", "SiteId", "dbo.Sites");
            DropIndex("dbo.SiteCircumstances", new[] { "SiteId" });
            DropTable("dbo.SiteCircumstances");
        }
    }
}
