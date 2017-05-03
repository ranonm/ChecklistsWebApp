namespace Checklists.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedPropertyToChecklist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checklists", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checklists", "IsDeleted");
        }
    }
}
