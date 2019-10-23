namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalFunctionsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Threads", "priotity", c => c.Boolean(nullable: false));
            AddColumn("dbo.Threads", "deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "deleted");
            DropColumn("dbo.Threads", "priotity");
            DropColumn("dbo.Posts", "deleted");
            DropColumn("dbo.Accounts", "deleted");
        }
    }
}
