using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.NetCore.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Residence_And_Residential_Transactions_Tables_Were_Added_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Residential_TransactionsUId",
                schema: "Home",
                table: "Residence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Residence_Transactions",
                schema: "Home",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentialId = table.Column<int>(type: "int", nullable: false),
                    ResidentialName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Block = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence_Transactions", x => x.UId);
                    table.ForeignKey(
                        name: "FK_Residence_Transactions_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Home",
                        principalTable: "Residential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residential_Transactions",
                schema: "Home",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    AllowEmergency = table.Column<bool>(type: "bit", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residential_Transactions", x => x.UId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Residence_Residential_TransactionsUId",
                schema: "Home",
                table: "Residence",
                column: "Residential_TransactionsUId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_Transactions_ResidentialId",
                schema: "Home",
                table: "Residence_Transactions",
                column: "ResidentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residence_Residential_Transactions_Residential_TransactionsUId",
                schema: "Home",
                table: "Residence",
                column: "Residential_TransactionsUId",
                principalSchema: "Home",
                principalTable: "Residential_Transactions",
                principalColumn: "UId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residence_Residential_Transactions_Residential_TransactionsUId",
                schema: "Home",
                table: "Residence");

            migrationBuilder.DropTable(
                name: "Residence_Transactions",
                schema: "Home");

            migrationBuilder.DropTable(
                name: "Residential_Transactions",
                schema: "Home");

            migrationBuilder.DropIndex(
                name: "IX_Residence_Residential_TransactionsUId",
                schema: "Home",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "Residential_TransactionsUId",
                schema: "Home",
                table: "Residence");
        }
    }
}
