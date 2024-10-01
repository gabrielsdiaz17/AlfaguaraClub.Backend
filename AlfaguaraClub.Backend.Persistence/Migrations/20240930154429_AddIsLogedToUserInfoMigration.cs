using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaguaraClub.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsLogedToUserInfoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoged",
                table: "UserInfo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoged",
                table: "UserInfo");
        }
    }
}
