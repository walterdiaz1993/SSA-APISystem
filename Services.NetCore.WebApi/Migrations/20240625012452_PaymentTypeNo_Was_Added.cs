using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTypeNo_Was_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentTypeNo",
                schema: "Payment",
                table: "PaymentType_Transactions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTypeNo",
                schema: "Payment",
                table: "PaymentType",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTypeNo",
                schema: "Payment",
                table: "PaymentType_Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentTypeNo",
                schema: "Payment",
                table: "PaymentType");
        }
    }
}
