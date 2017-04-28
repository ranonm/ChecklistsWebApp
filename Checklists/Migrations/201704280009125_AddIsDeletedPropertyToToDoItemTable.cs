namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedPropertyToToDoItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "IsDeleted");
        }
    }
}
