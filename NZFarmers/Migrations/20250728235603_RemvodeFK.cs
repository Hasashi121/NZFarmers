using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class RemvodeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2b30c800-15d5-4c6a-bffd-b9b0d829894f", new DateTime(2025, 7, 28, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(5327), "87cea874-4741-4891-bc7f-ede4a9e57b97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "c70052e5-f7e4-41cc-97c5-b5d4c3cc4faf", new DateTime(2025, 7, 28, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(5511), "8528f667-c9b9-4f17-8e9c-636e981ded61" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 28, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 3, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 8, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 10, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 23, 56, 2, 369, DateTimeKind.Utc).AddTicks(6081));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
