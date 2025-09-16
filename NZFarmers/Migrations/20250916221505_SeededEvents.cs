using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class SeededEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "965f7a21-79db-42ed-bb92-05fd11dc43bb", new DateTime(2025, 9, 16, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(1814), "593d5696-37ef-499e-8100-146fb9ef26f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "5a6af410-8107-4c57-8b65-510121de9b28", new DateTime(2025, 9, 16, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(1974), "f732fecc-efa8-49d0-9306-dcbac40b160f" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 17, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 27, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 4, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 22, 15, 3, 795, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.InsertData(
                table: "FarmerMarkets",
                columns: new[] { "EventID", "CreatedAt", "Date", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 14, 8, 0, 0, 0, DateTimeKind.Utc), "Seasonal produce, artisan breads, and live folk music from local performers.", "Claudelands Event Centre, Hamilton", "Hamilton Harvest Fair" },
                    { 2, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 5, 9, 30, 0, 0, DateTimeKind.Utc), "Celebrate spring with organic vegetables, flowers, and children's workshops.", "Cathedral Square, Christchurch", "Christchurch Spring Market" },
                    { 3, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 2, 7, 0, 0, 0, DateTimeKind.Utc), "Farm-to-table tastings featuring coastal seafood and fresh dairy selections.", "Wellington Waterfront, Wellington", "Wellington Waterfront Farmers" },
                    { 4, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 7, 9, 0, 0, 0, DateTimeKind.Utc), "Handmade preserves, cheeses, and cooking demos by local chefs.", "Octagon Square, Dunedin", "Otago Artisan Market" },
                    { 5, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Utc), "Evening market with gourmet street food, live DJs, and seasonal fruit stalls.", "Silo Park, Auckland", "Auckland Night Farmers Market" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerMarkets",
                keyColumn: "EventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FarmerMarkets",
                keyColumn: "EventID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FarmerMarkets",
                keyColumn: "EventID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FarmerMarkets",
                keyColumn: "EventID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FarmerMarkets",
                keyColumn: "EventID",
                keyValue: 5);

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
    }
}
