using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregoCustomerYotrosCamposAInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Block",
                schema: "Payment",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                schema: "Payment",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                schema: "Payment",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                schema: "Payment",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Customer",
                schema: "Payment",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                schema: "Payment",
                table: "Invoice");
        }
    }
}
