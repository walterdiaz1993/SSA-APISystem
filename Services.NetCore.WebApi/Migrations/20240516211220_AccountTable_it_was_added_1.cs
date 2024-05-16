using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AccountTable_it_was_added_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Security",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Security",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Security",
                table: "Account",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Security",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Security",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Security",
                table: "Account",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
