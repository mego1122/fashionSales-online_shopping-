using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FashionSales.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "104a5022-8131-4874-a927-787fa09d3839");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "104a5022-8131-4874-a927-787fa09d3839", "7869611c-0106-44da-affc-6bf15b34234f", "Admin", "ADMIN" });
        }
    }
}
