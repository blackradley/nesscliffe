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
                        Id = c.Guid(nullable: false),
                        AuthorityDensity = c.Double(nullable: false),
                        WardApproximatedSocialGradeAb = c.Int(nullable: false),
                        WardApproximatedSocialGradeC1 = c.Int(nullable: false),
                        WardApproximatedSocialGradeC2 = c.Int(nullable: false),
                        WardApproximatedSocialGradeDe = c.Int(nullable: false),
                        GooglePlaceId = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        GoogleRating = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sites", "SiteCircumstance_Id", c => c.Guid());
            CreateIndex("dbo.Sites", "SiteCircumstance_Id");
            AddForeignKey("dbo.Sites", "SiteCircumstance_Id", "dbo.SiteCircumstances", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "SiteCircumstance_Id", "dbo.SiteCircumstances");
            DropIndex("dbo.Sites", new[] { "SiteCircumstance_Id" });
            DropColumn("dbo.Sites", "SiteCircumstance_Id");
            DropTable("dbo.SiteCircumstances");
        }
    }
}
