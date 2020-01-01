namespace Company.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentID" });
            DropColumn("dbo.Employees", "DepartmentID");
            RenameColumn(table: "dbo.Employees", name: "Department_DepartmentID", newName: "DepartmentID");
            AlterColumn("dbo.Employees", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentID");
            AddForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            AlterColumn("dbo.Employees", "DepartmentID", c => c.Int());
            AlterColumn("dbo.Employees", "DepartmentID", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "DepartmentID", newName: "Department_DepartmentID");
            AddColumn("dbo.Employees", "DepartmentID", c => c.String());
            CreateIndex("dbo.Employees", "Department_DepartmentID");
            AddForeignKey("dbo.Employees", "Department_DepartmentID", "dbo.Departments", "DepartmentID");
        }
    }
}
