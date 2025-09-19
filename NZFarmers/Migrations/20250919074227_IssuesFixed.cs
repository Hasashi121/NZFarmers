using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZFarmers.Migrations
{
    /// <inheritdoc />
    public partial class IssuesFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContactNumber", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "seed-user-3", 0, "5f203b47-65f7-4022-9578-d4a4f8b6b515", "", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2662), "mike@example.com", true, "", "", false, null, "MIKE@EXAMPLE.COM", "MIKE@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "08ea6672-96de-4d11-9a64-ec1671bc053c", false, "mike@example.com" },
                    { "seed-user-4", 0, "afd3660d-32e4-4dca-92bc-b7bb0e8c261e", "", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2682), "jenny@example.com", true, "", "", false, null, "JENNY@EXAMPLE.COM", "JENNY@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "da699302-d73f-47f5-9ca3-1a3f0a7f14f7", false, "jenny@example.com" },
                    { "seed-user-5", 0, "d1dcbd35-233c-472b-88d9-e9fe1c2c28d7", "", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2700), "david@example.com", true, "", "", false, null, "DAVID@EXAMPLE.COM", "DAVID@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "524fa21a-e121-4ef9-bb43-eb24d48c6e8f", false, "david@example.com" },
                    { "seed-user-6", 0, "82ef1847-3d17-48e9-a14e-ae58fa11eaea", "", new DateTime(2025, 9, 19, 7, 42, 26, 814, DateTimeKind.Utc).AddTicks(2720), "anna@example.com", true, "", "", false, null, "ANNA@EXAMPLE.COM", "ANNA@EXAMPLE.COM", "PLACEHOLDER_HASH", null, false, 2, "f2ac6537-719a-468a-bacd-90211480161f", false, "anna@example.com" }
                });

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
                table: "FarmerMarketEvents",
                columns: new[] { "EventID", "CreatedAt", "Date", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { 15, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Utc), "Evening market with gourmet street food, live DJs, and seasonal fruit stalls.", "Silo Park, Auckland", "Auckland Night Farmers Market" },
                    { 35, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 5, 9, 30, 0, 0, DateTimeKind.Utc), "Celebrate spring with organic vegetables, flowers, and children's workshops.", "Cathedral Square, Christchurch", "Christchurch Spring Market" },
                    { 45, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 2, 7, 0, 0, 0, DateTimeKind.Utc), "Farm-to-table tastings featuring coastal seafood and fresh dairy selections.", "Wellington Waterfront, Wellington", "Wellington Waterfront Farmers" },
                    { 60, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 14, 8, 0, 0, 0, DateTimeKind.Utc), "Seasonal produce, artisan breads, and live folk music from local performers.", "Claudelands Event Centre, Hamilton", "Hamilton Harvest Fair" },
                    { 231, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 18, 8, 30, 0, 0, DateTimeKind.Utc), "Organic produce, fresh seafood, and artisan crafts by the bay.", "Tauranga Memorial Park, Tauranga", "Tauranga Bay Organic Market" },
                    { 912, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 7, 9, 0, 0, 0, DateTimeKind.Utc), "Handmade preserves, cheeses, and cooking demos by local chefs.", "Octagon Square, Dunedin", "Otago Artisan Market" },
                    { 1007, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 8, 9, 0, 0, 0, DateTimeKind.Utc), "Geothermally grown vegetables, Maori kai, and cultural performances.", "Government Gardens, Rotorua", "Rotorua Geothermal Growers" },
                    { 1008, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Wine tastings, grape harvest activities, and local produce showcase.", "Blenheim Town Square, Marlborough", "Marlborough Wine & Harvest Festival" },
                    { 1009, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 25, 8, 0, 0, 0, DateTimeKind.Utc), "Celebrating summer stone fruits with tastings, cooking demos, and orchard tours.", "Alexandra Township, Central Otago", "Central Otago Stone Fruit Fair" },
                    { 1010, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 22, 9, 30, 0, 0, DateTimeKind.Utc), "Dairy farm tours, cheese-making workshops, and fresh milk tastings.", "Pukekura Park, New Plymouth", "Taranaki Dairy Festival" },
                    { 1011, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 12, 8, 30, 0, 0, DateTimeKind.Utc), "Peninsula produce, native plants, and eco-friendly farming demonstrations.", "Thames Waterfront, Coromandel", "Coromandel Peninsula Market" },
                    { 1012, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 3, 10, 30, 0, 0, DateTimeKind.Utc), "Wild foods, foraged ingredients, and adventure cuisine from the West Coast.", "Greymouth Civic Centre, West Coast", "West Coast Wild Foods Market" }
                });

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { 0, "Tender young spinach leaves, perfect for salads.", "https://example.com/images/spinach.jpg", 4.25m, "Baby Spinach", 85 });

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 4,
                columns: new[] { "Category", "Description", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { 0, "Heirloom purple carrots with sweet flavor.", "https://example.com/images/purple-carrots.jpg", 3.80m, "Purple Carrots", 150 });

            migrationBuilder.InsertData(
                table: "FarmerProducts",
                columns: new[] { "FarmerProductID", "Category", "Description", "FarmerID", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[,]
                {
                    { 5, 0, "Sweet New Zealand kumara, orange variety.", 2, "https://example.com/images/kumara.jpg", 2.90m, "Kumara", 180 },
                    { 9, 1, "Tart blackcurrants, excellent for jams and desserts.", 3, "https://example.com/images/blackcurrants.jpg", 7.50m, "Blackcurrants", 60 },
                    { 13, 2, "Large pumpkin seeds for Halloween and cooking.", 3, "https://example.com/images/pumpkin-seeds.jpg", 4.25m, "Pumpkin Seeds", 250 },
                    { 15, 2, "Mixed lettuce seeds for continuous harvest.", 2, "https://example.com/images/lettuce-seeds.jpg", 6.75m, "Lettuce Variety Pack", 200 },
                    { 16, 3, "Dozen of fresh free-range eggs.", 3, "https://example.com/images/eggs.jpg", 5.00m, "Free Range Eggs", 75 },
                    { 31, 6, "Locally harvested honey from native bush.", 3, "https://example.com/images/honey.jpg", 8.99m, "Raw Clover Honey", 60 },
                    { 32, 6, "Premium Manuka honey with UMF 10+ rating.", 3, "https://example.com/images/manuka-honey.jpg", 25.99m, "Manuka Honey", 40 },
                    { 34, 6, "Strawberry jam made from fresh berries.", 2, "https://example.com/images/strawberry-jam.jpg", 7.25m, "Homemade Jam", 35 }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerID", "Address", "City", "Description", "FarmName", "PhoneNumber", "ProfileImage", "Region", "UserID", "ZipCode" },
                values: new object[,]
                {
                    { 4, "789 Alpine Road", "Taupo", "Premium dairy products from grass-fed cows.", "Mountain View Dairy", "+64273456789", "https://example.com/images/farm3.jpg", "Waikato", "seed-user-3", "3330" },
                    { 5, "321 Seaside Ave", "Napier", "Fresh citrus and stone fruits by the coast.", "Coastal Orchards", "+64298765432", "https://example.com/images/farm4.jpg", "Hawke's Bay", "seed-user-4", "4110" },
                    { 6, "654 Wheat Field Drive", "Palmerston North", "Traditional grains and ancient wheat varieties.", "Heritage Grains Co", "+64234567890", "https://example.com/images/farm5.jpg", "Manawatu", "seed-user-5", "4410" },
                    { 7, "987 Pasture Lane", "Invercargill", "Ethically raised grass-fed beef and lamb.", "Organic Meat Co", "+64245678901", "https://example.com/images/farm6.jpg", "Southland", "seed-user-6", "9810" }
                });

            migrationBuilder.InsertData(
                table: "FarmerProducts",
                columns: new[] { "FarmerProductID", "Category", "Description", "FarmerID", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[,]
                {
                    { 6, 1, "Crisp Royal Gala apples from coastal orchards.", 5, "https://example.com/images/apples.jpg", 4.50m, "Hawke's Bay Apples", 200 },
                    { 7, 1, "Sweet and juicy golden kiwifruit.", 5, "https://example.com/images/golden-kiwi.jpg", 6.99m, "Golden Kiwifruit", 120 },
                    { 8, 1, "Aromatic New Zealand feijoas, perfectly ripe.", 5, "https://example.com/images/feijoas.jpg", 5.25m, "Feijoas", 90 },
                    { 10, 1, "Exotic tree tomatoes with unique tangy flavor.", 5, "https://example.com/images/tamarillo.jpg", 8.25m, "Tamarillo", 45 },
                    { 11, 2, "Heirloom tomato seeds for home gardeners.", 6, "https://example.com/images/tomato-seeds.jpg", 3.99m, "Heritage Tomato Seeds", 500 },
                    { 12, 2, "Mixed herb seeds including basil, parsley, and cilantro.", 6, "https://example.com/images/herb-seeds.jpg", 5.50m, "Herb Garden Mix", 300 },
                    { 14, 2, "Giant sunflower seeds for beautiful garden displays.", 6, "https://example.com/images/sunflower-seeds.jpg", 2.99m, "Sunflower Seeds", 400 },
                    { 17, 3, "Creamy whole milk from grass-fed cows.", 4, "https://example.com/images/milk.jpg", 3.25m, "Fresh Whole Milk", 100 },
                    { 18, 3, "Sharp aged cheddar, matured for 12 months.", 4, "https://example.com/images/cheddar.jpg", 12.99m, "Aged Cheddar Cheese", 30 },
                    { 19, 3, "Thick and creamy Greek-style yogurt.", 4, "https://example.com/images/yogurt.jpg", 6.50m, "Greek Style Yogurt", 80 },
                    { 20, 3, "Rich and creamy butter from grass-fed cows.", 4, "https://example.com/images/butter.jpg", 4.75m, "Grass-Fed Butter", 60 },
                    { 21, 4, "Premium lean beef mince from grass-fed cattle.", 7, "https://example.com/images/beef-mince.jpg", 15.99m, "Grass-Fed Beef Mince", 40 },
                    { 22, 4, "Tender lamb chops from free-range sheep.", 7, "https://example.com/images/lamb-chops.jpg", 22.50m, "Lamb Chops", 25 },
                    { 23, 4, "Whole free-range chicken, hormone-free.", 7, "https://example.com/images/chicken.jpg", 18.75m, "Free Range Chicken", 35 },
                    { 24, 4, "Wild venison steaks, lean and flavorful.", 7, "https://example.com/images/venison.jpg", 28.99m, "Venison Steaks", 20 },
                    { 25, 4, "Smoked bacon from heritage breed pigs.", 7, "https://example.com/images/bacon.jpg", 12.25m, "Bacon", 45 },
                    { 26, 5, "Stone-ground flour from heritage wheat.", 6, "https://example.com/images/wheat-flour.jpg", 4.99m, "Organic Wheat Flour", 150 },
                    { 27, 5, "Traditional rolled oats, perfect for breakfast.", 6, "https://example.com/images/oats.jpg", 3.75m, "Rolled Oats", 200 },
                    { 28, 5, "High-protein quinoa, locally grown.", 6, "https://example.com/images/quinoa.jpg", 8.50m, "Quinoa", 80 },
                    { 29, 5, "Nutritious brown rice, short grain variety.", 6, "https://example.com/images/brown-rice.jpg", 5.25m, "Brown Rice", 120 },
                    { 30, 5, "Hulled barley, excellent for soups and stews.", 6, "https://example.com/images/barley.jpg", 3.99m, "Barley", 100 },
                    { 33, 6, "Cold-pressed extra virgin olive oil.", 5, "https://example.com/images/olive-oil.jpg", 14.50m, "Olive Oil", 55 },
                    { 35, 6, "Mixed fresh herbs: rosemary, thyme, and sage.", 4, "https://example.com/images/herb-bundle.jpg", 4.99m, "Fresh Herbs Bundle", 70 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "FarmerMarketEvents",
                keyColumn: "EventID",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "seed-user-6");

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

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { 6, "Locally harvested honey from native bush.", "https://example.com/images/honey.jpg", 8.99m, "Raw Clover Honey", 60 });

            migrationBuilder.UpdateData(
                table: "FarmerProducts",
                keyColumn: "FarmerProductID",
                keyValue: 4,
                columns: new[] { "Category", "Description", "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { 3, "Dozen of fresh free-range eggs.", "https://example.com/images/eggs.jpg", 5.00m, "Free Range Eggs", 75 });
        }
    }
}
