namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecurityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "security", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "security", c => c.Int(nullable: false));
            AddColumn("dbo.Threads", "security", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "security", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "security");
            DropColumn("dbo.Threads", "security");
            DropColumn("dbo.Boards", "security");
            DropColumn("dbo.Accounts", "security");
        }
    }
}
