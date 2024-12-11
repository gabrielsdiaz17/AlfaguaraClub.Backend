using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaguaraClub.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SlotsForSpaceActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SpaceActivitySlotId",
                table: "Booking",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpaceActivitySlot",
                columns: table => new
                {
                    SpaceActivitySlotId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpaceActivityId = table.Column<long>(type: "bigint", nullable: false),
                    RailNumber = table.Column<int>(type: "int", nullable: false),
                    MaxQuorum = table.Column<int>(type: "int", nullable: false),
                    CurrentQuorum = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceActivitySlot", x => x.SpaceActivitySlotId);
                    table.ForeignKey(
                        name: "FK_SpaceActivitySlot_SpaceActivity_SpaceActivityId",
                        column: x => x.SpaceActivityId,
                        principalTable: "SpaceActivity",
                        principalColumn: "SpaceActivityId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SpaceActivitySlotId",
                table: "Booking",
                column: "SpaceActivitySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceActivitySlot_SpaceActivityId",
                table: "SpaceActivitySlot",
                column: "SpaceActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_SpaceActivitySlot_SpaceActivitySlotId",
                table: "Booking",
                column: "SpaceActivitySlotId",
                principalTable: "SpaceActivitySlot",
                principalColumn: "SpaceActivitySlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_SpaceActivitySlot_SpaceActivitySlotId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "SpaceActivitySlot");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SpaceActivitySlotId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SpaceActivitySlotId",
                table: "Booking");
        }
    }
}
