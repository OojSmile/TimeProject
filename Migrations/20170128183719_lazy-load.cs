using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeApplication.Migrations
{
    public partial class lazyload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Projects",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employees",
                newName: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Projects",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "ID");
        }
    }
}
