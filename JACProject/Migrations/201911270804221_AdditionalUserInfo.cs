namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "location", c => c.String());
            AddColumn("dbo.Accounts", "profileImageURL", c => c.String());
            AddColumn("dbo.Accounts", "showEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Accounts", "nickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "nickName");
            DropColumn("dbo.Accounts", "showEmail");
            DropColumn("dbo.Accounts", "profileImageURL");
            DropColumn("dbo.Accounts", "location");
        }
    }
}
