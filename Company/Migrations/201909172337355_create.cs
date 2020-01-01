namespace Company.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeAge = c.Int(nullable: false),
                        EmployeeSalary = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
