using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregoResidentialIdYotrosCamposAInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Block",
                schema: "Payment",
                table: "Invoice_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                schema: "Payment",
                table: "Invoice_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                schema: "Payment",
                table: "Invoice_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "Invoice_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                schema: "Payment",
                table: "Invoice_Transactions");

            migrationBuilder.DropColumn(
                name: "Customer",
                schema: "Payment",
                table: "Invoice_Transactions");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                schema: "Payment",
                table: "Invoice_Transactions");

            migrationBuilder.DropColumn(
                name: "ResidentialId",
                schema: "Payment",
                table: "Invoice_Transactions");

            migrationBuilder.DropColumn(
                name: "ResidentialId",
                schema: "Payment",
                table: "Invoice");
        }
    }
}
