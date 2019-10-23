namespace JACProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubBoardsRemovedSectionsAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boards", "SubBoard_id", "dbo.SubBoards");
            DropForeignKey("dbo.Threads", "SubBoard_id", "dbo.SubBoards");
            DropIndex("dbo.Boards", new[] { "SubBoard_id" });
            DropIndex("dbo.Threads", new[] { "SubBoard_id" });
            AddColumn("dbo.Boards", "name", c => c.String());
            AddColumn("dbo.Boards", "initial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Boards", "section", c => c.String());
            DropColumn("dbo.Boards", "SubBoard_id");
            DropColumn("dbo.Threads", "SubBoard_id");
            DropTable("dbo.SubBoards");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Threads", "SubBoard_id", c => c.Int());
            AddColumn("dbo.Boards", "SubBoard_id", c => c.Int());
            DropColumn("dbo.Boards", "section");
            DropColumn("dbo.Boards", "initial");
            DropColumn("dbo.Boards", "name");
            CreateIndex("dbo.Threads", "SubBoard_id");
            CreateIndex("dbo.Boards", "SubBoard_id");
            AddForeignKey("dbo.Threads", "SubBoard_id", "dbo.SubBoards", "id");
            AddForeignKey("dbo.Boards", "SubBoard_id", "dbo.SubBoards", "id");
        }
    }
}
