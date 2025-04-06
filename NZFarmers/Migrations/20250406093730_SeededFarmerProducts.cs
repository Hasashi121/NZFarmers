using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class SeededFarmerProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "12f39b95-5134-4cc7-a4fc-429d57547ea4", new DateTime(2025, 4, 6, 9, 37, 28, 579, DateTimeKind.Utc).AddTicks(4251), "c681e662-5bd4-480a-a9c6-c7cf846dd66c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "f83557cd-d746-43b2-a0fe-16bd737117c2", new DateTime(2025, 4, 6, 9, 37, 28, 579, DateTimeKind.Utc).AddTicks(4432), "d8645b5e-8caa-4604-ae7d-da3fa145f67c" });

            migrationBuilder.InsertData(
                table: "FarmerProducts",
                columns: new[] { "FarmerProductID", "Category", "Description", "FarmerID", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[,]
                {
                    { 1, 0, "Juicy and pesticide-free tomatoes.", 2, "https://example.com/images/tomatoes.jpg", 3.50m, "Organic Tomatoes", 120 },
                    { 2, 0, "Golden corn, perfect for BBQs.", 2, "https://example.com/images/corn.jpg", 2.20m, "Sweet Corn", 200 },
                    { 3, 6, "Locally harvested honey from native bush.", 3, "https://example.com/images/honey.jpg", 8.99m, "Raw Clover Honey", 60 },
                    { 4, 3, "Dozen of fresh free-range eggs.", 3, "https://example.com/images/eggs.jpg", 5.00m, "Free Range Eggs", 75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "ffc8fca1-e97a-4edf-be63-364eab6a3b71", new DateTime(2025, 4, 4, 1, 7, 30, 329, DateTimeKind.Utc).AddTicks(4884), "9a7433fa-b5be-4990-a6d2-f26f244e8d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "affc6f88-8001-4db2-bb01-85156cc2a607", new DateTime(2025, 4, 4, 1, 7, 30, 329, DateTimeKind.Utc).AddTicks(5066), "d6676d5c-e129-40bb-9bac-c20f93ff31e0" });
        }
    }
}
