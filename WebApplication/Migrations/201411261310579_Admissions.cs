namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admissions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Months", "IncomeAdmissions", c => c.Int(nullable: false));
            AddColumn("dbo.Months", "IncomeAdditional", c => c.Int(nullable: false));
            AddColumn("dbo.Months", "VisitorsAdditional", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Months", "VisitorsAdditional");
            DropColumn("dbo.Months", "IncomeAdditional");
            DropColumn("dbo.Months", "IncomeAdmissions");
        }
    }
}
