using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class SeededEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "EducationalContents",
                columns: new[] { "ContentID", "ContentURL", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { 10, "https://www.mpi.govt.nz/agriculture/sustainable-farming/", new DateTime(2025, 5, 27, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2407), "Learn about eco-friendly farming methods that work best in New Zealand's unique climate and soil conditions. Discover how to reduce environmental impact while maintaining productivity.", "Sustainable Farming Practices for New Zealand" },
                    { 20, "https://www.asurequality.com/our-services/organic-certification/", new DateTime(2025, 6, 1, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2419), "Step-by-step guide to obtaining organic certification for your farm products. Understand the requirements, documentation needed, and benefits of organic farming.", "Organic Certification Guide" },
                    { 30, "https://www.landcareresearch.co.nz/discover-our-research/environment/soils/", new DateTime(2025, 6, 6, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2423), "Essential tips for maintaining healthy soil and optimizing nutrient levels. Learn about composting, crop rotation, and natural fertilizers.", "Soil Health and Nutrition Management" },
                    { 40, "https://www.niwa.co.nz/agriculture/irrigation", new DateTime(2025, 6, 8, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2427), "Effective strategies for water management and conservation on your farm. Discover irrigation techniques that save water while maximizing crop yield.", "Water Conservation in Agriculture" },
                    { 50, "https://www.plantandfood.co.nz/page/agriculture/pest-management/", new DateTime(2025, 6, 11, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2431), "Integrated pest management strategies that protect your crops naturally. Learn to identify common pests and diseases affecting New Zealand farms.", "Pest and Disease Management" },
                    { 60, "https://www.mpi.govt.nz/agriculture/climate-change/", new DateTime(2025, 6, 14, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2435), "Prepare your farm for changing weather patterns and extreme events. Strategies for building resilience and adapting to climate variability.", "Climate Change Adaptation for Farmers" },
                    { 70, "https://www.marketgardening.co.nz/direct-marketing/", new DateTime(2025, 6, 16, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2439), "Learn how to sell directly to consumers and restaurants. Build relationships with local buyers and maximize your profit margins through direct sales.", "Direct Marketing and Farm-to-Table Sales" },
                    { 80, "https://www.gardening.co.nz/vegetables/planting-calendar/", new DateTime(2025, 6, 18, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2444), "Month-by-month guide to planting vegetables and fruits in New Zealand. Optimize your growing seasons and plan for year-round production.", "Seasonal Planting Calendar for NZ" },
                    { 90, "https://www.worksafe.govt.nz/topic-and-industry/agriculture/", new DateTime(2025, 6, 21, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2448), "Essential safety practices and risk management strategies for farm operations. Protect yourself, your workers, and your property.", "Farm Safety and Risk Management" },
                    { 100, "https://www.agritech.org.nz/resources/", new DateTime(2025, 6, 23, 2, 39, 8, 141, DateTimeKind.Utc).AddTicks(2452), "Explore how technology can improve farm efficiency and productivity. From GPS tractors to soil sensors, discover the latest agricultural innovations.", "Technology in Modern Farming" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "EducationalContents",
                keyColumn: "ContentID",
                keyValue: 100);

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
    }
}
