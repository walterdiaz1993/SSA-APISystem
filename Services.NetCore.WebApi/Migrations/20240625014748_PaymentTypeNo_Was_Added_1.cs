using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTypeNo_Was_Added_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType");

            migrationBuilder.AddColumn<int>(
                name: "LatePayment",
                schema: "Payment",
                table: "PaymentType_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LatePayment",
                schema: "Payment",
                table: "PaymentType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                column: "ResidentialId",
                principalSchema: "Home",
                principalTable: "Residential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "LatePayment",
                schema: "Payment",
                table: "PaymentType_Transactions");

            migrationBuilder.DropColumn(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType_Transactions");

            migrationBuilder.DropColumn(
                name: "LatePayment",
                schema: "Payment",
                table: "PaymentType");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Residential_ResidentialId",
                schema: "Payment",
                table: "PaymentType",
                column: "ResidentialId",
                principalSchema: "Home",
                principalTable: "Residential",
                principalColumn: "Id");
        }
    }
}
