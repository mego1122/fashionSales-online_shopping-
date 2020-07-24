using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FashionSales.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "708cf725-17a2-400a-b096-79c359ec8514");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "OrderProducts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9df4e05b-a9b8-4d34-afef-b320f6b168c9", "638639c1-c609-41da-8a51-b85fedfb066d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9df4e05b-a9b8-4d34-afef-b320f6b168c9");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "OrderProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "708cf725-17a2-400a-b096-79c359ec8514", "2cfa0363-a514-464a-9257-5d7c52287155", "Admin", "ADMIN" });
        }
    }
}
