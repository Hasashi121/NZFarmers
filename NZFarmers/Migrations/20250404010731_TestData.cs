using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContactNumber", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "seed-user-1", 0, "ffc8fca1-e97a-4edf-be63-364eab6a3b71", "", new DateTime(2025, 4, 4, 1, 7, 30, 329, DateTimeKind.Utc).AddTicks(4884), "sarah@example.com", true, "", "", false, null, "SARAH@EXAMPLE.COM", "SARAH@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "9a7433fa-b5be-4990-a6d2-f26f244e8d45", false, "sarah@example.com" },
                    { "seed-user-2", 0, "affc6f88-8001-4db2-bb01-85156cc2a607", "", new DateTime(2025, 4, 4, 1, 7, 30, 329, DateTimeKind.Utc).AddTicks(5066), "tom@example.com", true, "", "", false, null, "TOM@EXAMPLE.COM", "TOM@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "d6676d5c-e129-40bb-9bac-c20f93ff31e0", false, "tom@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerID", "Address", "City", "Description", "FarmName", "PhoneNumber", "ProfileImage", "Region", "UserID", "ZipCode" },
                values: new object[,]
                {
                    { 2, "456 Harvest Rd", "Christchurch", "Locally sourced vegetables and fruits.", "Sunny Fields", "+64287654321", "https://example.com/images/farm2.jpg", "Canterbury", "seed-user-2", "8011" },
                    { 3, "123 Orchard Lane", "Hamilton", "Specializing in organic produce.", "Green Valley Farms", "+64212345678", "https://example.com/images/farm1.jpg", "Waikato", "seed-user-1", "3204" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2");
        }
    }
}
