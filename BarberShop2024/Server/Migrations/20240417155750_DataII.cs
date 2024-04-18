using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop2024.Server.Migrations
{
    /// <inheritdoc />
    public partial class DataII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Customers_CustomerId",
                table: "BookMarks");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Customers_CustomerId",
                table: "BookMarks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Customers_CustomerId",
                table: "BookMarks");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Customers_CustomerId",
                table: "BookMarks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
