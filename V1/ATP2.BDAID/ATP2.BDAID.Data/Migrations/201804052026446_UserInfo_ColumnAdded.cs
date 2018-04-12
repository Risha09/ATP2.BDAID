namespace ATP2.BDAID.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfo_ColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Name", c => c.String(nullable: false));
            AddColumn("dbo.UserInfoes", "Email", c => c.String(nullable: false));
            AddColumn("dbo.UserInfoes", "Contact", c => c.String(nullable: false));
            AddColumn("dbo.UserInfoes", "ConfirmPassword", c => c.String(nullable: false));
            AddColumn("dbo.UserInfoes", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfoes", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Gender");
            DropColumn("dbo.UserInfoes", "Age");
            DropColumn("dbo.UserInfoes", "ConfirmPassword");
            DropColumn("dbo.UserInfoes", "Contact");
            DropColumn("dbo.UserInfoes", "Email");
            DropColumn("dbo.UserInfoes", "Name");
        }
    }
}
