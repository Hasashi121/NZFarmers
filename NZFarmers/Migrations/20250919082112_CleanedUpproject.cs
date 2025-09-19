using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class CleanedUpproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryTrackings");

            migrationBuilder.DropTable(
                name: "FarmerMarketParticipations");

            migrationBuilder.DropTable(
                name: "FarmerMarkets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "a4139feb-ba6d-4039-b451-258c92662a2d", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7130), "b5a00211-a9cb-42fe-af7c-c03fa56ca11f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "70ef334e-ce24-4ad9-b20a-c47a25ed9fb6", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7221), "f74681e5-b090-4aa9-a4bc-cd5d234734ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "247b50bd-aafe-47a8-9f3c-40e1ebd31f99", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7275), "e86a0f6e-f7fb-4d6e-8d9b-6078c759dcf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "aca012bb-b176-45bd-b058-9692efac82cb", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7296), "4ef9a8aa-b154-4dcc-9b4c-ad0dbc6ca1a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "57e5133d-3b36-4522-ab76-bd94bff6e1be", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7315), "c51c054f-97b5-4f54-abb5-7d8e84d67269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "da45b188-4b99-441f-92ad-53af8f4ff297", new DateTime(2025, 9, 19, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7345), "e05234c4-c671-4ebc-b4f1-e1ba093ff79d" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 20, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 4, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 7, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 9, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 8, 21, 11, 723, DateTimeKind.Utc).AddTicks(7741));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryTrackings",
                columns: table => new
                {
                    TrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTrackings", x => x.TrackingID);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmerMarkets",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerMarkets", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "FarmerMarketParticipations",
                columns: table => new
                {
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    FarmerMarketsEventID = table.Column<int>(type: "int", nullable: true),
                    ParticipationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerMarketParticipations", x => new { x.FarmerID, x.EventID });
                    table.ForeignKey(
                        name: "FK_FarmerMarketParticipations_FarmerMarketEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "FarmerMarketEvents",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmerMarketParticipations_FarmerMarkets_FarmerMarketsEventID",
                        column: x => x.FarmerMarketsEventID,
                        principalTable: "FarmerMarkets",
                        principalColumn: "EventID");
                    table.ForeignKey(
                        name: "FK_FarmerMarketParticipations_Farmers_FarmerID",
                        column: x => x.FarmerID,
                        principalTable: "Farmers",
                        principalColumn: "FarmerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "030bcf7f-4001-4259-b508-dc152502e0fa", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2537), "ac39f6a8-c6bb-4431-93d0-6494367d2127" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "f12a5dbc-ed4f-4ad2-931f-5cafe6fb8fb6", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2635), "eebed5fd-11fb-4601-8229-5daf4184eecf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "5f203b47-65f7-4022-9578-d4a4f8b6b515", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2662), "08ea6672-96de-4d11-9a64-ec1671bc053c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "afd3660d-32e4-4dca-92bc-b7bb0e8c261e", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2682), "da699302-d73f-47f5-9ca3-1a3f0a7f14f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "d1dcbd35-233c-472b-88d9-e9fe1c2c28d7", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2700), "524fa21a-e121-4ef9-bb43-eb24d48c6e8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-6",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "82ef1847-3d17-48e9-a14e-ae58fa11eaea", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2720), "f2ac6537-719a-468a-bacd-90211480161f" });

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 20, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 4, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 7, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 9, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 14, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(3188));

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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_OrderID",
                table: "DeliveryTrackings",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FarmerMarketParticipations_EventID",
                table: "FarmerMarketParticipations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerMarketParticipations_FarmerMarketsEventID",
                table: "FarmerMarketParticipations",
                column: "FarmerMarketsEventID");
        }
    }
}
