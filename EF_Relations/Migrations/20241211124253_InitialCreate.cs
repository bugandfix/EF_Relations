using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Relations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxpayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxpayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaxPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRecords_Taxpayers_TaxPayerID",
                        column: x => x.TaxPayerID,
                        principalTable: "Taxpayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Taxpayers",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Ali" },
                    { 2, "Reza" },
                    { 3, "Sara" }
                });

            migrationBuilder.InsertData(
                table: "TaxRecords",
                columns: new[] { "Id", "TaxCode", "TaxPayerID", "TotalTaxPaid" },
                values: new object[,]
                {
                    { 1, "TAX12345", 1, 5000.00m },
                    { 2, "TAX67890", 2, 7500.00m },
                    { 3, "TAX54321", 3, 3000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxRecords_TaxPayerID",
                table: "TaxRecords",
                column: "TaxPayerID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRecords");

            migrationBuilder.DropTable(
                name: "Taxpayers");
        }
    }
}
