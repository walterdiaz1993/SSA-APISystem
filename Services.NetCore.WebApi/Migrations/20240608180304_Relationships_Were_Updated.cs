using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Relationships_Were_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionUserRole",
                schema: "SecurityManagement");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "SecurityManagement",
                table: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PermissionUserRole",
                schema: "SecurityManagement",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    UserRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUserRole", x => new { x.PermissionsId, x.UserRolesId });
                    table.ForeignKey(
                        name: "FK_PermissionUserRole_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalSchema: "SecurityManagement",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUserRole_UserRole_UserRolesId",
                        column: x => x.UserRolesId,
                        principalSchema: "SecurityManagement",
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUserRole_UserRolesId",
                schema: "SecurityManagement",
                table: "PermissionUserRole",
                column: "UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_UserRole_UserRoleId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserRoleId",
                principalSchema: "SecurityManagement",
                principalTable: "UserRole",
                principalColumn: "Id");
        }
    }
}
