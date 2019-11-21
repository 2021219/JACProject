namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        timeCreated = c.DateTime(nullable: false),
                        creator_id = c.Int(),
                        Thread_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.creator_id)
                .ForeignKey("dbo.Threads", t => t.Thread_id)
                .Index(t => t.creator_id)
                .Index(t => t.Thread_id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Thread_id", "dbo.Threads");
            DropForeignKey("dbo.Posts", "creator_id", "dbo.Accounts");
            DropIndex("dbo.Posts", new[] { "Thread_id" });
            DropIndex("dbo.Posts", new[] { "creator_id" });
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
            DropTable("dbo.Accounts");
        }
    }
}
