using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmerProductID1",
                table: "FarmerProducts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "048dc205-5af3-46ac-ad5e-d0e75d91d06b", new DateTime(2025, 7, 28, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(5832), "7126e95c-a481-45b5-9eef-a0df012c0b2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "bffd0a89-f7d2-433a-81c5-1e4c81afd7c6", new DateTime(2025, 7, 28, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6069), "1e82d0dc-fb20-457a-b828-6213bec6bf25" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 28, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 8, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 10, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 54, 52, 248, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 1,
                column: "FarmerProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 2,
                column: "FarmerProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 3,
                column: "FarmerProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 4,
                column: "FarmerProductID1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_FarmerProducts_FarmerProductID1",
                table: "FarmerProducts",
                column: "FarmerProductID1");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerProducts_FarmerProducts_FarmerProductID1",
                table: "FarmerProducts",
                column: "FarmerProductID1",
                principalTable: "FarmerProducts",
                principalColumn: "FarmerProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerProducts_FarmerProducts_FarmerProductID1",
                table: "FarmerProducts");

            migrationBuilder.DropIndex(
                name: "IX_FarmerProducts_FarmerProductID1",
                table: "FarmerProducts");

            migrationBuilder.DropColumn(
                name: "FarmerProductID1",
                table: "FarmerProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "dfb9565a-3cf3-4c3d-973f-7ffd413ae0d1", new DateTime(2025, 6, 26, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(1681), "d0628762-da3a-4131-aabf-d3f2f92f0b63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "3d11a3c1-2a03-4c95-a8ac-90779894eb5f", new DateTime(2025, 6, 26, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(1858), "467ea77f-253a-47b3-a6c2-bbd877fc6a4a" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 27, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 6, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 14, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 16, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 18, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2452));
        }
    }
}
