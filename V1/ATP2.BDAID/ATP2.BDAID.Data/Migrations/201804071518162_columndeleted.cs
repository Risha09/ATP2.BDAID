namespace ATP2.BDAID.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columndeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "ConfirmPassword", c => c.String(nullable: false));
        }
    }
}
