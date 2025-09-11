using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeOfferingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Employees_EmployeeId",
                table: "Offerings");

            migrationBuilder.DropIndex(
                name: "IX_Offerings_EmployeeId",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Offerings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Offerings",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_EmployeeId",
                table: "Offerings",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Employees_EmployeeId",
                table: "Offerings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
