namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        deleted = c.Boolean(nullable: false),
                        order = c.Int(nullable: false),
                        Board_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Boards", t => t.Board_id)
                .Index(t => t.Board_id);
            
            AddColumn("dbo.Threads", "Board_id", c => c.Int());
            CreateIndex("dbo.Threads", "Board_id");
            AddForeignKey("dbo.Threads", "Board_id", "dbo.Boards", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "Board_id", "dbo.Boards");
            DropForeignKey("dbo.Boards", "Board_id", "dbo.Boards");
            DropIndex("dbo.Threads", new[] { "Board_id" });
            DropIndex("dbo.Boards", new[] { "Board_id" });
            DropColumn("dbo.Threads", "Board_id");
            DropTable("dbo.Boards");
        }
    }
}
