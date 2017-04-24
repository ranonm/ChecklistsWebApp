using System.Windows.Markup;

namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddChecklistsEntries : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Shopping', '6/19/2015 10:35:50 AM')");
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Chores', '6/19/2015 10:35:50 AM')");
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Meal prep', '6/19/2015 10:35:50 AM')");
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Workout', '6/19/2015 10:35:50 AM')");
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Moving list', '6/19/2015 10:35:50 AM')");
            Sql("INSERT INTO Checklists (Name, DateAdded) VALUES ('Movies to watch', '6/19/2015 10:35:50 AM')");
        }

        public override void Down()
        {
        }
    }
}
