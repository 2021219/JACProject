namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTitles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "title");
        }
    }
}
