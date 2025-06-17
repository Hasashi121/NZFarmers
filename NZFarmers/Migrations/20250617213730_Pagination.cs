using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class Pagination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
