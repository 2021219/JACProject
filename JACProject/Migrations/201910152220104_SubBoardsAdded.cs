namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubBoardsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubBoards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        deleted = c.Boolean(nullable: false),
                        order = c.Int(nullable: false),
                        security = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Boards", "SubBoard_id", c => c.Int());
            AddColumn("dbo.Threads", "SubBoard_id", c => c.Int());
            CreateIndex("dbo.Boards", "SubBoard_id");
            CreateIndex("dbo.Threads", "SubBoard_id");
            AddForeignKey("dbo.Boards", "SubBoard_id", "dbo.SubBoards", "id");
            AddForeignKey("dbo.Threads", "SubBoard_id", "dbo.SubBoards", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "SubBoard_id", "dbo.SubBoards");
            DropForeignKey("dbo.Boards", "SubBoard_id", "dbo.SubBoards");
            DropIndex("dbo.Threads", new[] { "SubBoard_id" });
            DropIndex("dbo.Boards", new[] { "SubBoard_id" });
            DropColumn("dbo.Threads", "SubBoard_id");
            DropColumn("dbo.Boards", "SubBoard_id");
            DropTable("dbo.SubBoards");
        }
    }
}
