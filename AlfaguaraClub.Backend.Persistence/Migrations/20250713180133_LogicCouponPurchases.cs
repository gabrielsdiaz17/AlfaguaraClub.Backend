using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaguaraClub.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogicCouponPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PublicVisibility",
                table: "Product",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MonthlyCouponBook",
                columns: table => new
                {
                    MonthlyCouponBookId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MembershipId = table.Column<long>(type: "bigint", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCouponBook", x => x.MonthlyCouponBookId);
                    table.ForeignKey(
                        name: "FK_MonthlyCouponBook_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CouponPurchase",
                columns: table => new
                {
                    CouponPurchaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonthlyCouponBookId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Comment = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponPurchase", x => x.CouponPurchaseId);
                    table.ForeignKey(
                        name: "FK_CouponPurchase_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenter",
                        principalColumn: "CostCenterId");
                    table.ForeignKey(
                        name: "FK_CouponPurchase_MonthlyCouponBook_MonthlyCouponBookId",
                        column: x => x.MonthlyCouponBookId,
                        principalTable: "MonthlyCouponBook",
                        principalColumn: "MonthlyCouponBookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponPurchase_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponPurchase_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPurchase_CostCenterId",
                table: "CouponPurchase",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPurchase_MonthlyCouponBookId",
                table: "CouponPurchase",
                column: "MonthlyCouponBookId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPurchase_ProductId",
                table: "CouponPurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPurchase_UserId",
                table: "CouponPurchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCouponBook_MembershipId",
                table: "MonthlyCouponBook",
                column: "MembershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponPurchase");

            migrationBuilder.DropTable(
                name: "MonthlyCouponBook");

            migrationBuilder.DropColumn(
                name: "PublicVisibility",
                table: "Product");
        }
    }
}
