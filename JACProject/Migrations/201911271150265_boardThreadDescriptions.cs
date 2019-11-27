namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boardThreadDescriptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "description", c => c.String());
            AddColumn("dbo.Threads", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "description");
            DropColumn("dbo.Boards", "description");
        }
    }
}
