namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "AspNetUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sites", "AspNetUserId");
        }
    }
}
