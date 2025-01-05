namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdateCustomeradded1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "BirthDate", c => c.DateTime());
        }
    }
}
