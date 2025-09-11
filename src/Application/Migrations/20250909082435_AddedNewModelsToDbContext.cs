using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModelsToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_EmployeeOffering_EmployeeOfferingId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Employee_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_User_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Businesses_BusinessId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffering_Employee_EmployeeId",
                table: "EmployeeOffering");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffering_Offerings_OfferingId",
                table: "EmployeeOffering");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Employee_EmployeeId",
                table: "Offerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_OfferingCategory_CategoryId",
                table: "Offerings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferingCategory",
                table: "OfferingCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOffering",
                table: "EmployeeOffering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "OfferingCategory",
                newName: "OfferingCategories");

            migrationBuilder.RenameTable(
                name: "EmployeeOffering",
                newName: "EmployeeOfferings");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOffering_OfferingId",
                table: "EmployeeOfferings",
                newName: "IX_EmployeeOfferings_OfferingId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOffering_EmployeeId",
                table: "EmployeeOfferings",
                newName: "IX_EmployeeOfferings_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_BusinessId",
                table: "Employees",
                newName: "IX_Employees_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferingCategories",
                table: "OfferingCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOfferings",
                table: "EmployeeOfferings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_EmployeeOfferings_EmployeeOfferingId",
                table: "Appointments",
                column: "EmployeeOfferingId",
                principalTable: "EmployeeOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOfferings_Employees_EmployeeId",
                table: "EmployeeOfferings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOfferings_Offerings_OfferingId",
                table: "EmployeeOfferings",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Businesses_BusinessId",
                table: "Employees",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Employees_EmployeeId",
                table: "Offerings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_OfferingCategories_CategoryId",
                table: "Offerings",
                column: "CategoryId",
                principalTable: "OfferingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_EmployeeOfferings_EmployeeOfferingId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOfferings_Employees_EmployeeId",
                table: "EmployeeOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOfferings_Offerings_OfferingId",
                table: "EmployeeOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Businesses_BusinessId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Employees_EmployeeId",
                table: "Offerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_OfferingCategories_CategoryId",
                table: "Offerings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferingCategories",
                table: "OfferingCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOfferings",
                table: "EmployeeOfferings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "OfferingCategories",
                newName: "OfferingCategory");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeOfferings",
                newName: "EmployeeOffering");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Employee",
                newName: "IX_Employee_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BusinessId",
                table: "Employee",
                newName: "IX_Employee_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOfferings_OfferingId",
                table: "EmployeeOffering",
                newName: "IX_EmployeeOffering_OfferingId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOfferings_EmployeeId",
                table: "EmployeeOffering",
                newName: "IX_EmployeeOffering_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferingCategory",
                table: "OfferingCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOffering",
                table: "EmployeeOffering",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_EmployeeOffering_EmployeeOfferingId",
                table: "Appointments",
                column: "EmployeeOfferingId",
                principalTable: "EmployeeOffering",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Employee_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_User_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Businesses_BusinessId",
                table: "Employee",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffering_Employee_EmployeeId",
                table: "EmployeeOffering",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffering_Offerings_OfferingId",
                table: "EmployeeOffering",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Employee_EmployeeId",
                table: "Offerings",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_OfferingCategory_CategoryId",
                table: "Offerings",
                column: "CategoryId",
                principalTable: "OfferingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
