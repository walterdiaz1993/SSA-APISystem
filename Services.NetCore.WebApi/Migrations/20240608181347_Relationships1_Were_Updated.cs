using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Relationships1_Were_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "SecurityManagement",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                schema: "SecurityManagement",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "SecurityManagement",
                table: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "SecurityManagement",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "SecurityManagement",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                schema: "SecurityManagement",
                table: "Role",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "SecurityManagement",
                table: "UserRole",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
