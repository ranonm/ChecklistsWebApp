namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireAuthorForChecklist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Checklists", new[] { "AuthorId" });
            AlterColumn("dbo.Checklists", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Checklists", "AuthorId");
            AddForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Checklists", new[] { "AuthorId" });
            AlterColumn("dbo.Checklists", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checklists", "AuthorId");
            AddForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
