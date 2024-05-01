using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberShop2024.Server.Migrations
{
    /// <inheritdoc />
    public partial class Data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServicesSelect",
                table: "BookMarks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ShopName", "UserAdress", "UserEmail", "UserName", "UserPassword", "UserPhone" },
                values: new object[,]
                {
                    { 1, "Loja 1", "Endereço 1", "usuario1@example.com", "Usuário 1", "senha123", 123456789 },
                    { 2, "Loja 2", "Endereço 2", "usuario2@example.com", "Usuário 2", "senha456", 987654321 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerEmail", "CustomerName", "NIF", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1, "cliente1@example.com", "Cliente 1", 123456789, "987654321", 2 },
                    { 2, "cliente2@example.com", "Cliente 2", 987654321, "123456789", 2 }
                });

            migrationBuilder.InsertData(
                table: "ServicesBarbers",
                columns: new[] { "ServiceId", "ServiceDescription", "ServiceName", "ServicePrice", "UserId" },
                values: new object[,]
                {
                    { 1, "Descrição do serviço 1", "Corte de Cabelo Masculino", 20.0, 1 },
                    { 2, "Descrição do serviço 2", "Corte de Cabelo Feminino", 25.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookMarks",
                columns: new[] { "BookMarkId", "CustomerId", "DateBook", "ServicesSelect" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 1, 10, 9, 27, 725, DateTimeKind.Local).AddTicks(4972), "Corte de Cabelo Masculino" },
                    { 2, 2, new DateTime(2024, 5, 2, 10, 9, 27, 725, DateTimeKind.Local).AddTicks(5098), "Corte de Cabelo Feminino" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookMarks",
                keyColumn: "BookMarkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookMarks",
                keyColumn: "BookMarkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServicesBarbers",
                keyColumn: "ServiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServicesBarbers",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ServicesSelect",
                table: "BookMarks");
        }
    }
}
