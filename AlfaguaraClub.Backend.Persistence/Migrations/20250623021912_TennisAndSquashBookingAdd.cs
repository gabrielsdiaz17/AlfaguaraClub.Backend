using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaguaraClub.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TennisAndSquashBookingAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SquashFieldActivitySlotId",
                table: "Booking",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TennisFieldActivitySlotId",
                table: "Booking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SquashFieldActivitySlot",
                columns: table => new
                {
                    SquashFieldActivitySlotId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpaceActivityId = table.Column<long>(type: "bigint", nullable: false),
                    FieldNumber = table.Column<int>(type: "int", nullable: false),
                    AvailableSlots = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquashFieldActivitySlot", x => x.SquashFieldActivitySlotId);
                    table.ForeignKey(
                        name: "FK_SquashFieldActivitySlot_SpaceActivity_SpaceActivityId",
                        column: x => x.SpaceActivityId,
                        principalTable: "SpaceActivity",
                        principalColumn: "SpaceActivityId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TennisFieldActivitySlot",
                columns: table => new
                {
                    TennisFieldActivitySlotId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpaceActivityId = table.Column<long>(type: "bigint", nullable: false),
                    FieldNumber = table.Column<int>(type: "int", nullable: false),
                    AvailableSlots = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TennisFieldActivitySlot", x => x.TennisFieldActivitySlotId);
                    table.ForeignKey(
                        name: "FK_TennisFieldActivitySlot_SpaceActivity_SpaceActivityId",
                        column: x => x.SpaceActivityId,
                        principalTable: "SpaceActivity",
                        principalColumn: "SpaceActivityId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SquashFieldActivitySlotId",
                table: "Booking",
                column: "SquashFieldActivitySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TennisFieldActivitySlotId",
                table: "Booking",
                column: "TennisFieldActivitySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SquashFieldActivitySlot_SpaceActivityId",
                table: "SquashFieldActivitySlot",
                column: "SpaceActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisFieldActivitySlot_SpaceActivityId",
                table: "TennisFieldActivitySlot",
                column: "SpaceActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_SquashFieldActivitySlot_SquashFieldActivitySlotId",
                table: "Booking",
                column: "SquashFieldActivitySlotId",
                principalTable: "SquashFieldActivitySlot",
                principalColumn: "SquashFieldActivitySlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_TennisFieldActivitySlot_TennisFieldActivitySlotId",
                table: "Booking",
                column: "TennisFieldActivitySlotId",
                principalTable: "TennisFieldActivitySlot",
                principalColumn: "TennisFieldActivitySlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_SquashFieldActivitySlot_SquashFieldActivitySlotId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_TennisFieldActivitySlot_TennisFieldActivitySlotId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "SquashFieldActivitySlot");

            migrationBuilder.DropTable(
                name: "TennisFieldActivitySlot");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SquashFieldActivitySlotId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TennisFieldActivitySlotId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SquashFieldActivitySlotId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TennisFieldActivitySlotId",
                table: "Booking");
        }
    }
}
