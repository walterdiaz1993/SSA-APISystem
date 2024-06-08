using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RoleTable_Was_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUserRole",
                schema: "SecurityManagement");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_UserRole_UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserRoleId",
                principalSchema: "SecurityManagement",
                principalTable: "UserRole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_UserRole_UserRoleId",
                schema: "SecurityManagement",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserRoleId",
                schema: "SecurityManagement",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "SecurityManagement",
                table: "Role");

            migrationBuilder.CreateTable(
                name: "RoleUserRole",
                schema: "SecurityManagement",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UserRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUserRole", x => new { x.RolesId, x.UserRolesId });
                    table.ForeignKey(
                        name: "FK_RoleUserRole_Role_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "SecurityManagement",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUserRole_UserRole_UserRolesId",
                        column: x => x.UserRolesId,
                        principalSchema: "SecurityManagement",
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserRole_UserRolesId",
                schema: "SecurityManagement",
                table: "RoleUserRole",
                column: "UserRolesId");
        }
    }
}
