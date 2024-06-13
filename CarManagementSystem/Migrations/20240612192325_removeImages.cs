using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class removeImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
