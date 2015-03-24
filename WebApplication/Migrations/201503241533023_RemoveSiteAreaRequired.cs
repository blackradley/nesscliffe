namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSiteAreaRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sites", "AreaIndoor", c => c.Int());
            AlterColumn("dbo.Sites", "AreaOutdoor", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sites", "AreaOutdoor", c => c.Single(nullable: false));
            AlterColumn("dbo.Sites", "AreaIndoor", c => c.Int(nullable: false));
        }
    }
}
