namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorToChecklistTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checklists", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checklists", "AuthorId");
            AddForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checklists", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Checklists", new[] { "AuthorId" });
            DropColumn("dbo.Checklists", "AuthorId");
        }
    }
}
