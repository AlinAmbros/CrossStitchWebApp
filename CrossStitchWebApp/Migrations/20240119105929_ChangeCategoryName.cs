using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrossStitchWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceCategory",
                table: "Rooms",
                newName: "RoomCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomCategory",
                table: "Rooms",
                newName: "RaceCategory");
        }
    }
}
