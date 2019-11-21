namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "priority", c => c.Boolean(nullable: false));
            DropColumn("dbo.Threads", "priotity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "priotity", c => c.Boolean(nullable: false));
            DropColumn("dbo.Threads", "priority");
        }
    }
}
