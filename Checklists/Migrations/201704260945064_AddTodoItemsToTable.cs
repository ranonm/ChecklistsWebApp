namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTodoItemsToTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TodoItems (Title, Checked, DateAdded, ChecklistId) VALUES ('Shoes', 'false', '4/25/2017 5:58:50 AM', 11)");
            Sql("INSERT INTO TodoItems (Title, Checked, DateAdded, ChecklistId) VALUES ('Shirt', 'false', '4/25/2017 5:59:50 AM', 11)");
            Sql("INSERT INTO TodoItems (Title, Checked, DateAdded, ChecklistId) VALUES ('Shorts', 'false', '4/25/2017 6:00:00 AM', 11)");
            Sql("INSERT INTO TodoItems (Title, Checked, DateAdded, ChecklistId) VALUES ('Pants', 'false', '4/25/2017 6:30:50 AM', 11)");
        }

        public override void Down()
        {
        }
    }
}
