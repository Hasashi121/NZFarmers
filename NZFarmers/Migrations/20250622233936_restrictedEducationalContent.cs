using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class restrictedEducationalContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "5542f7be-05e9-40de-aa95-d6b2bae6f2e0", new DateTime(2025, 6, 22, 23, 39, 34, 50, DateTimeKind.Utc).AddTicks(1437), "923e6274-80c0-4619-8471-6a75c3a83317" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "37a73a5f-1e79-4ff7-bd2e-3c09eccf765f", new DateTime(2025, 6, 22, 23, 39, 34, 50, DateTimeKind.Utc).AddTicks(1610), "2f7b80fd-7698-4a95-8fca-e7655072ab27" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "fd4c5225-0773-4ccb-8741-d06fa31cfd81", new DateTime(2025, 6, 17, 21, 37, 27, 914, DateTimeKind.Utc).AddTicks(4605), "c70f8338-9495-430d-8745-c981429220d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "b8cb4f36-782c-400f-b67c-c821b37aab6c", new DateTime(2025, 6, 17, 21, 37, 27, 914, DateTimeKind.Utc).AddTicks(4801), "080edf1b-bcbb-45f3-9da2-8afd2f4751c5" });
        }
    }
}
