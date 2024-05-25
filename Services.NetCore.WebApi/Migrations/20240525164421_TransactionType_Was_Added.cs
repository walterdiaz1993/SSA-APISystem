using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class TransactionType_Was_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "Security",
                table: "User_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "Security",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "ExceptionHandler",
                table: "RequestParameter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "ExceptionHandler",
                table: "LogExceptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "Security",
                table: "Account_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                schema: "Security",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Security",
                table: "User_Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "ExceptionHandler",
                table: "RequestParameter");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "ExceptionHandler",
                table: "LogExceptions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Security",
                table: "Account_Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Security",
                table: "Account");
        }
    }
}
