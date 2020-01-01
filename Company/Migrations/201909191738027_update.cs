namespace Company.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DepartmentID", c => c.String());
            DropColumn("dbo.Employees", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            DropColumn("dbo.Employees", "DepartmentID");
        }
    }
}
