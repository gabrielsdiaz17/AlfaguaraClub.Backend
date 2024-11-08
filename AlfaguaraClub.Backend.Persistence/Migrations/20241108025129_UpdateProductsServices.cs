using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaguaraClub.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CostCenterId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CostCenterId",
                table: "Product",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CostCenter_CostCenterId",
                table: "Product",
                column: "CostCenterId",
                principalTable: "CostCenter",
                principalColumn: "CostCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CostCenter_CostCenterId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CostCenterId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "Product");
        }
    }
}
