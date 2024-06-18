using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Vehicles_VehicleId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Vehicles_VehicleId",
                table: "Transactions",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Vehicles_VehicleId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Vehicles_VehicleId",
                table: "Transactions",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
