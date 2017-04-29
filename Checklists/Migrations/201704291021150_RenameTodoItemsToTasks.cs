namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTodoItemsToTasks : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TodoItems", newName: "Tasks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tasks", newName: "TodoItems");
        }
    }
}
