namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postCountAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "postCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "postCount");
        }
    }
}
