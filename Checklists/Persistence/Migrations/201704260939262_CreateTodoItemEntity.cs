namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTodoItemEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Checked = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ChecklistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Checklists", t => t.ChecklistId, cascadeDelete: true)
                .Index(t => t.ChecklistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "ChecklistId", "dbo.Checklists");
            DropIndex("dbo.TodoItems", new[] { "ChecklistId" });
            DropTable("dbo.TodoItems");
        }
    }
}
