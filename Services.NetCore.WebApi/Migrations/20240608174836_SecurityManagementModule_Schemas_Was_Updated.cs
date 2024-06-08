using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SecurityManagementModule_Schemas_Was_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserRole_Transactions",
                schema: "Security",
                newName: "UserRole_Transactions",
                newSchema: "SecurityManagement");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "Security",
                newName: "UserRole",
                newSchema: "SecurityManagement");

            migrationBuilder.RenameTable(
                name: "RoleUserRole",
                schema: "EfCore_dbo",
                newName: "RoleUserRole",
                newSchema: "SecurityManagement");

            migrationBuilder.RenameTable(
                name: "PermissionUserRole",
                schema: "Security",
                newName: "PermissionUserRole",
                newSchema: "SecurityManagement");

            migrationBuilder.RenameTable(
                name: "Permission_Transactions",
                schema: "Security",
                newName: "Permission_Transactions",
                newSchema: "SecurityManagement");

            migrationBuilder.RenameTable(
                name: "Permission",
                schema: "Security",
                newName: "Permission",
                newSchema: "SecurityManagement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EfCore_dbo");

            migrationBuilder.RenameTable(
                name: "UserRole_Transactions",
                schema: "SecurityManagement",
                newName: "UserRole_Transactions",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "SecurityManagement",
                newName: "UserRole",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "RoleUserRole",
                schema: "SecurityManagement",
                newName: "RoleUserRole",
                newSchema: "EfCore_dbo");

            migrationBuilder.RenameTable(
                name: "PermissionUserRole",
                schema: "SecurityManagement",
                newName: "PermissionUserRole",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "Permission_Transactions",
                schema: "SecurityManagement",
                newName: "Permission_Transactions",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "Permission",
                schema: "SecurityManagement",
                newName: "Permission",
                newSchema: "Security");
        }
    }
}
