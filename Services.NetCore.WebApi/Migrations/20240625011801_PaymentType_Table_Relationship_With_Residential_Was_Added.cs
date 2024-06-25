using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PaymentType_Table_Relationship_With_Residential_Was_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                column: "ResidentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                column: "ResidentialId",
                principalSchema: "Home",
                principalTable: "Residential",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_ResidentialId",
                schema: "Payment",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType");
        }
    }
}
