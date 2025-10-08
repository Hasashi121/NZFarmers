using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Models;
using NZFarmers.ViewModels;
using System.Reflection.Emit;

namespace NZFarmers.Data;

public class NZFarmersContext : IdentityDbContext<NZFarmersUser>
{
    public NZFarmersContext(DbContextOptions<NZFarmersContext> options)
        : base(options)
    {

    }
    public DbSet<NZFarmersUser> NZFarmersUser { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public DbSet<Farmers> Farmers { get; set; }
    public DbSet<FarmerProduct> FarmerProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<EducationalContent> EducationalContents { get; set; }
    public DbSet<FarmerMarketEvent> FarmerMarketEvents { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<NZFarmersUser>().HasData(
     new NZFarmersUser
     {
         Id = "seed-user-1",
         UserName = "sarah@example.com",
         NormalizedUserName = "SARAH@EXAMPLE.COM",
         Email = "sarah@example.com",
         NormalizedEmail = "SARAH@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     },
     new NZFarmersUser
     {
         Id = "seed-user-2",
         UserName = "tom@example.com",
         NormalizedUserName = "TOM@EXAMPLE.COM",
         Email = "tom@example.com",
         NormalizedEmail = "TOM@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     },
     new NZFarmersUser
     {
         Id = "seed-user-3",
         UserName = "mike@example.com",
         NormalizedUserName = "MIKE@EXAMPLE.COM",
         Email = "mike@example.com",
         NormalizedEmail = "MIKE@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     },
     new NZFarmersUser
     {
         Id = "seed-user-4",
         UserName = "jenny@example.com",
         NormalizedUserName = "JENNY@EXAMPLE.COM",
         Email = "jenny@example.com",
         NormalizedEmail = "JENNY@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     },
     new NZFarmersUser
     {
         Id = "seed-user-5",
         UserName = "david@example.com",
         NormalizedUserName = "DAVID@EXAMPLE.COM",
         Email = "david@example.com",
         NormalizedEmail = "DAVID@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     },
     new NZFarmersUser
     {
         Id = "seed-user-6",
         UserName = "anna@example.com",
         NormalizedUserName = "ANNA@EXAMPLE.COM",
         Email = "anna@example.com",
         NormalizedEmail = "ANNA@EXAMPLE.COM",
         EmailConfirmed = true,
         PasswordHash = "PLACEHOLDER_HASH",
         SecurityStamp = Guid.NewGuid().ToString("D"),
         ConcurrencyStamp = Guid.NewGuid().ToString("D")
     }
 );

        builder.Entity<Farmers>().HasData(
        new Farmers
        {
            FarmerID = 3,
            UserID = "seed-user-1",
            FarmName = "Green Valley Farms",
            Description = "Specializing in organic produce.",
            PhoneNumber = "+64212345678",
            ProfileImage = "https://example.com/images/farm1.jpg",
            Address = "123 Orchard Lane",
            City = "Hamilton",
            Region = "Waikato",
            ZipCode = "3204"
        },
    new Farmers
    {
        FarmerID = 2,
        UserID = "seed-user-2",
        FarmName = "Sunny Fields",
        Description = "Locally sourced vegetables and fruits.",
        PhoneNumber = "+64287654321",
        ProfileImage = "https://example.com/images/farm2.jpg",
        Address = "456 Harvest Rd",
        City = "Christchurch",
        Region = "Canterbury",
        ZipCode = "8011"
    },
    // New farmers
    new Farmers
    {
        FarmerID = 4,
        UserID = "seed-user-3",
        FarmName = "Mountain View Dairy",
        Description = "Premium dairy products from grass-fed cows.",
        PhoneNumber = "+64273456789",
        ProfileImage = "https://example.com/images/farm3.jpg",
        Address = "789 Alpine Road",
        City = "Taupo",
        Region = "Waikato",
        ZipCode = "3330"
    },
    new Farmers
    {
        FarmerID = 5,
        UserID = "seed-user-4",
        FarmName = "Coastal Orchards",
        Description = "Fresh citrus and stone fruits by the coast.",
        PhoneNumber = "+64298765432",
        ProfileImage = "https://example.com/images/farm4.jpg",
        Address = "321 Seaside Ave",
        City = "Napier",
        Region = "Hawke's Bay",
        ZipCode = "4110"
    },
    new Farmers
    {
        FarmerID = 6,
        UserID = "seed-user-5",
        FarmName = "Heritage Grains Co",
        Description = "Traditional grains and ancient wheat varieties.",
        PhoneNumber = "+64234567890",
        ProfileImage = "https://example.com/images/farm5.jpg",
        Address = "654 Wheat Field Drive",
        City = "Palmerston North",
        Region = "Manawatu",
        ZipCode = "4410"
    },
    new Farmers
    {
        FarmerID = 7,
        UserID = "seed-user-6",
        FarmName = "Organic Meat Co",
        Description = "Ethically raised grass-fed beef and lamb.",
        PhoneNumber = "+64245678901",
        ProfileImage = "https://example.com/images/farm6.jpg",
        Address = "987 Pasture Lane",
        City = "Invercargill",
        Region = "Southland",
        ZipCode = "9810"
    }
    );

        builder.Entity<FarmerProduct>().HasData(
    // VEGETABLES (8 products)
    new FarmerProduct
    {
        FarmerProductID = 1,
        FarmerID = 2,
        ProductName = "Organic Tomatoes",
        Description = "Juicy and pesticide-free tomatoes.",
        Category = ProductCategory.Vegetables,
        Price = 3.50m,
        Stock = 120,
        ImageURL = "https://example.com/images/tomatoes.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 2,
        FarmerID = 2,
        ProductName = "Sweet Corn",
        Description = "Golden corn, perfect for BBQs.",
        Category = ProductCategory.Vegetables,
        Price = 2.20m,
        Stock = 200,
        ImageURL = "https://example.com/images/corn.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 3,
        FarmerID = 3,
        ProductName = "Baby Spinach",
        Description = "Tender young spinach leaves, perfect for salads.",
        Category = ProductCategory.Vegetables,
        Price = 4.25m,
        Stock = 85,
        ImageURL = "https://example.com/images/spinach.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 4,
        FarmerID = 3,
        ProductName = "Purple Carrots",
        Description = "Heirloom purple carrots with sweet flavor.",
        Category = ProductCategory.Vegetables,
        Price = 3.80m,
        Stock = 150,
        ImageURL = "https://example.com/images/purple-carrots.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 5,
        FarmerID = 2,
        ProductName = "Kumara",
        Description = "Sweet New Zealand kumara, orange variety.",
        Category = ProductCategory.Vegetables,
        Price = 2.90m,
        Stock = 180,
        ImageURL = "https://example.com/images/kumara.jpg"
    },

    // FRUITS (5 products)
    new FarmerProduct
    {
        FarmerProductID = 6,
        FarmerID = 5,
        ProductName = "Hawke's Bay Apples",
        Description = "Crisp Royal Gala apples from coastal orchards.",
        Category = ProductCategory.Fruits,
        Price = 4.50m,
        Stock = 200,
        ImageURL = "https://example.com/images/apples.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 7,
        FarmerID = 5,
        ProductName = "Golden Kiwifruit",
        Description = "Sweet and juicy golden kiwifruit.",
        Category = ProductCategory.Fruits,
        Price = 6.99m,
        Stock = 120,
        ImageURL = "https://example.com/images/golden-kiwi.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 8,
        FarmerID = 5,
        ProductName = "Feijoas",
        Description = "Aromatic New Zealand feijoas, perfectly ripe.",
        Category = ProductCategory.Fruits,
        Price = 5.25m,
        Stock = 90,
        ImageURL = "https://example.com/images/feijoas.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 9,
        FarmerID = 3,
        ProductName = "Blackcurrants",
        Description = "Tart blackcurrants, excellent for jams and desserts.",
        Category = ProductCategory.Fruits,
        Price = 7.50m,
        Stock = 60,
        ImageURL = "https://example.com/images/blackcurrants.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 10,
        FarmerID = 5,
        ProductName = "Tamarillo",
        Description = "Exotic tree tomatoes with unique tangy flavor.",
        Category = ProductCategory.Fruits,
        Price = 8.25m,
        Stock = 45,
        ImageURL = "https://example.com/images/tamarillo.jpg"
    },

    // SEEDS (5 products)
    new FarmerProduct
    {
        FarmerProductID = 11,
        FarmerID = 6,
        ProductName = "Heritage Tomato Seeds",
        Description = "Heirloom tomato seeds for home gardeners.",
        Category = ProductCategory.Seeds,
        Price = 3.99m,
        Stock = 500,
        ImageURL = "https://example.com/images/tomato-seeds.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 12,
        FarmerID = 6,
        ProductName = "Herb Garden Mix",
        Description = "Mixed herb seeds including basil, parsley, and cilantro.",
        Category = ProductCategory.Seeds,
        Price = 5.50m,
        Stock = 300,
        ImageURL = "https://example.com/images/herb-seeds.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 13,
        FarmerID = 3,
        ProductName = "Pumpkin Seeds",
        Description = "Large pumpkin seeds for Halloween and cooking.",
        Category = ProductCategory.Seeds,
        Price = 4.25m,
        Stock = 250,
        ImageURL = "https://example.com/images/pumpkin-seeds.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 14,
        FarmerID = 6,
        ProductName = "Sunflower Seeds",
        Description = "Giant sunflower seeds for beautiful garden displays.",
        Category = ProductCategory.Seeds,
        Price = 2.99m,
        Stock = 400,
        ImageURL = "https://example.com/images/sunflower-seeds.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 15,
        FarmerID = 2,
        ProductName = "Lettuce Variety Pack",
        Description = "Mixed lettuce seeds for continuous harvest.",
        Category = ProductCategory.Seeds,
        Price = 6.75m,
        Stock = 200,
        ImageURL = "https://example.com/images/lettuce-seeds.jpg"
    },

    // DAIRY (5 products)
    new FarmerProduct
    {
        FarmerProductID = 16,
        FarmerID = 3,
        ProductName = "Free Range Eggs",
        Description = "Dozen of fresh free-range eggs.",
        Category = ProductCategory.Dairy,
        Price = 5.00m,
        Stock = 75,
        ImageURL = "https://example.com/images/eggs.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 17,
        FarmerID = 4,
        ProductName = "Fresh Whole Milk",
        Description = "Creamy whole milk from grass-fed cows.",
        Category = ProductCategory.Dairy,
        Price = 3.25m,
        Stock = 100,
        ImageURL = "https://example.com/images/milk.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 18,
        FarmerID = 4,
        ProductName = "Aged Cheddar Cheese",
        Description = "Sharp aged cheddar, matured for 12 months.",
        Category = ProductCategory.Dairy,
        Price = 12.99m,
        Stock = 30,
        ImageURL = "https://example.com/images/cheddar.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 19,
        FarmerID = 4,
        ProductName = "Greek Style Yogurt",
        Description = "Thick and creamy Greek-style yogurt.",
        Category = ProductCategory.Dairy,
        Price = 6.50m,
        Stock = 80,
        ImageURL = "https://example.com/images/yogurt.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 20,
        FarmerID = 4,
        ProductName = "Grass-Fed Butter",
        Description = "Rich and creamy butter from grass-fed cows.",
        Category = ProductCategory.Dairy,
        Price = 4.75m,
        Stock = 60,
        ImageURL = "https://example.com/images/butter.jpg"
    },

    // MEAT (5 products)
    new FarmerProduct
    {
        FarmerProductID = 21,
        FarmerID = 7,
        ProductName = "Grass-Fed Beef Mince",
        Description = "Premium lean beef mince from grass-fed cattle.",
        Category = ProductCategory.Meat,
        Price = 15.99m,
        Stock = 40,
        ImageURL = "https://example.com/images/beef-mince.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 22,
        FarmerID = 7,
        ProductName = "Lamb Chops",
        Description = "Tender lamb chops from free-range sheep.",
        Category = ProductCategory.Meat,
        Price = 22.50m,
        Stock = 25,
        ImageURL = "https://example.com/images/lamb-chops.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 23,
        FarmerID = 7,
        ProductName = "Free Range Chicken",
        Description = "Whole free-range chicken, hormone-free.",
        Category = ProductCategory.Meat,
        Price = 18.75m,
        Stock = 35,
        ImageURL = "https://example.com/images/chicken.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 24,
        FarmerID = 7,
        ProductName = "Venison Steaks",
        Description = "Wild venison steaks, lean and flavorful.",
        Category = ProductCategory.Meat,
        Price = 28.99m,
        Stock = 20,
        ImageURL = "https://example.com/images/venison.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 25,
        FarmerID = 7,
        ProductName = "Bacon",
        Description = "Smoked bacon from heritage breed pigs.",
        Category = ProductCategory.Meat,
        Price = 12.25m,
        Stock = 45,
        ImageURL = "https://example.com/images/bacon.jpg"
    },

    // GRAINS (5 products)
    new FarmerProduct
    {
        FarmerProductID = 26,
        FarmerID = 6,
        ProductName = "Organic Wheat Flour",
        Description = "Stone-ground flour from heritage wheat.",
        Category = ProductCategory.Grains,
        Price = 4.99m,
        Stock = 150,
        ImageURL = "https://example.com/images/wheat-flour.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 27,
        FarmerID = 6,
        ProductName = "Rolled Oats",
        Description = "Traditional rolled oats, perfect for breakfast.",
        Category = ProductCategory.Grains,
        Price = 3.75m,
        Stock = 200,
        ImageURL = "https://example.com/images/oats.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 28,
        FarmerID = 6,
        ProductName = "Quinoa",
        Description = "High-protein quinoa, locally grown.",
        Category = ProductCategory.Grains,
        Price = 8.50m,
        Stock = 80,
        ImageURL = "https://example.com/images/quinoa.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 29,
        FarmerID = 6,
        ProductName = "Brown Rice",
        Description = "Nutritious brown rice, short grain variety.",
        Category = ProductCategory.Grains,
        Price = 5.25m,
        Stock = 120,
        ImageURL = "https://example.com/images/brown-rice.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 30,
        FarmerID = 6,
        ProductName = "Barley",
        Description = "Hulled barley, excellent for soups and stews.",
        Category = ProductCategory.Grains,
        Price = 3.99m,
        Stock = 100,
        ImageURL = "https://example.com/images/barley.jpg"
    },

    // OTHER (5 products)
    new FarmerProduct
    {
        FarmerProductID = 31,
        FarmerID = 3,
        ProductName = "Raw Clover Honey",
        Description = "Locally harvested honey from native bush.",
        Category = ProductCategory.Other,
        Price = 8.99m,
        Stock = 60,
        ImageURL = "https://example.com/images/honey.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 32,
        FarmerID = 3,
        ProductName = "Manuka Honey",
        Description = "Premium Manuka honey with UMF 10+ rating.",
        Category = ProductCategory.Other,
        Price = 25.99m,
        Stock = 40,
        ImageURL = "https://example.com/images/manuka-honey.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 33,
        FarmerID = 5,
        ProductName = "Olive Oil",
        Description = "Cold-pressed extra virgin olive oil.",
        Category = ProductCategory.Other,
        Price = 14.50m,
        Stock = 55,
        ImageURL = "https://example.com/images/olive-oil.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 34,
        FarmerID = 2,
        ProductName = "Homemade Jam",
        Description = "Strawberry jam made from fresh berries.",
        Category = ProductCategory.Other,
        Price = 7.25m,
        Stock = 35,
        ImageURL = "https://example.com/images/strawberry-jam.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 35,
        FarmerID = 4,
        ProductName = "Fresh Herbs Bundle",
        Description = "Mixed fresh herbs: rosemary, thyme, and sage.",
        Category = ProductCategory.Other,
        Price = 4.99m,
        Stock = 70,
        ImageURL = "https://example.com/images/herb-bundle.jpg"
    }
);
        
        builder.Entity<FarmerMarketEvent>().HasData(
    new FarmerMarketEvent
    {
        EventID = 60,
        Title = "Hamilton Harvest Fair",
        Location = "Claudelands Event Centre, Hamilton",
        Date = new DateTime(2024, 9, 14, 8, 0, 0, DateTimeKind.Utc),
        Description = "Seasonal produce, artisan breads, and live folk music from local performers.",
        CreatedAt = new DateTime(2024, 8, 1, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 35,
        Title = "Christchurch Spring Market",
        Location = "Cathedral Square, Christchurch",
        Date = new DateTime(2024, 10, 5, 9, 30, 0, DateTimeKind.Utc),
        Description = "Celebrate spring with organic vegetables, flowers, and children's workshops.",
        CreatedAt = new DateTime(2024, 8, 5, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 45,
        Title = "Wellington Waterfront Farmers",
        Location = "Wellington Waterfront, Wellington",
        Date = new DateTime(2024, 11, 2, 7, 0, 0, DateTimeKind.Utc),
        Description = "Farm-to-table tastings featuring coastal seafood and fresh dairy selections.",
        CreatedAt = new DateTime(2024, 8, 10, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 912,
        Title = "Otago Artisan Market",
        Location = "Octagon Square, Dunedin",
        Date = new DateTime(2024, 12, 7, 9, 0, 0, DateTimeKind.Utc),
        Description = "Handmade preserves, cheeses, and cooking demos by local chefs.",
        CreatedAt = new DateTime(2024, 8, 15, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 15,
        Title = "Auckland Night Farmers Market",
        Location = "Silo Park, Auckland",
        Date = new DateTime(2024, 9, 28, 16, 0, 0, DateTimeKind.Utc),
        Description = "Evening market with gourmet street food, live DJs, and seasonal fruit stalls.",
        CreatedAt = new DateTime(2024, 8, 20, 0, 0, 0, DateTimeKind.Utc)
    },
    // New farmer market events
    new FarmerMarketEvent
    {
        EventID = 231,
        Title = "Tauranga Bay Organic Market",
        Location = "Tauranga Memorial Park, Tauranga",
        Date = new DateTime(2025, 1, 18, 8, 30, 0, DateTimeKind.Utc),
        Description = "Organic produce, fresh seafood, and artisan crafts by the bay.",
        CreatedAt = new DateTime(2024, 8, 25, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1007,
        Title = "Rotorua Geothermal Growers",
        Location = "Government Gardens, Rotorua",
        Date = new DateTime(2025, 2, 8, 9, 0, 0, DateTimeKind.Utc),
        Description = "Geothermally grown vegetables, Maori kai, and cultural performances.",
        CreatedAt = new DateTime(2024, 9, 1, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1008,
        Title = "Marlborough Wine & Harvest Festival",
        Location = "Blenheim Town Square, Marlborough",
        Date = new DateTime(2025, 3, 15, 10, 0, 0, DateTimeKind.Utc),
        Description = "Wine tastings, grape harvest activities, and local produce showcase.",
        CreatedAt = new DateTime(2024, 9, 5, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1009,
        Title = "Central Otago Stone Fruit Fair",
        Location = "Alexandra Township, Central Otago",
        Date = new DateTime(2025, 1, 25, 8, 0, 0, DateTimeKind.Utc),
        Description = "Celebrating summer stone fruits with tastings, cooking demos, and orchard tours.",
        CreatedAt = new DateTime(2024, 9, 10, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1010,
        Title = "Taranaki Dairy Festival",
        Location = "Pukekura Park, New Plymouth",
        Date = new DateTime(2025, 2, 22, 9, 30, 0, DateTimeKind.Utc),
        Description = "Dairy farm tours, cheese-making workshops, and fresh milk tastings.",
        CreatedAt = new DateTime(2024, 9, 15, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1011,
        Title = "Coromandel Peninsula Market",
        Location = "Thames Waterfront, Coromandel",
        Date = new DateTime(2025, 4, 12, 8, 30, 0, DateTimeKind.Utc),
        Description = "Peninsula produce, native plants, and eco-friendly farming demonstrations.",
        CreatedAt = new DateTime(2024, 9, 20, 0, 0, 0, DateTimeKind.Utc)
    },
    new FarmerMarketEvent
    {
        EventID = 1012,
        Title = "West Coast Wild Foods Market",
        Location = "Greymouth Civic Centre, West Coast",
        Date = new DateTime(2025, 5, 3, 10, 30, 0, DateTimeKind.Utc),
        Description = "Wild foods, foraged ingredients, and adventure cuisine from the West Coast.",
        CreatedAt = new DateTime(2024, 9, 25, 0, 0, 0, DateTimeKind.Utc)
    }
);
        // Educational Content Seed Data
        builder.Entity<EducationalContent>().HasData(
            new EducationalContent
            {
                ContentID = 10,
                Title = "Sustainable Farming Practices for New Zealand",
                Description = "Learn about eco-friendly farming methods that work best in New Zealand's unique climate and soil conditions. Discover how to reduce environmental impact while maintaining productivity.",
                ContentURL = "https://www.mpi.govt.nz/agriculture/sustainable-farming/",
                CreatedAt = DateTime.UtcNow.AddDays(-30)
            },
            new EducationalContent
            {
                ContentID = 20,
                Title = "Organic Certification Guide",
                Description = "Step-by-step guide to obtaining organic certification for your farm products. Understand the requirements, documentation needed, and benefits of organic farming.",
                ContentURL = "https://www.asurequality.com/our-services/organic-certification/",
                CreatedAt = DateTime.UtcNow.AddDays(-25)
            },
            new EducationalContent
            {
                ContentID = 30,
                Title = "Soil Health and Nutrition Management",
                Description = "Essential tips for maintaining healthy soil and optimizing nutrient levels. Learn about composting, crop rotation, and natural fertilizers.",
                ContentURL = "https://www.landcareresearch.co.nz/discover-our-research/environment/soils/",
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new EducationalContent
            {
                ContentID = 40,
                Title = "Water Conservation in Agriculture",
                Description = "Effective strategies for water management and conservation on your farm. Discover irrigation techniques that save water while maximizing crop yield.",
                ContentURL = "https://www.niwa.co.nz/agriculture/irrigation",
                CreatedAt = DateTime.UtcNow.AddDays(-18)
            },
            new EducationalContent
            {
                ContentID = 50,
                Title = "Pest and Disease Management",
                Description = "Integrated pest management strategies that protect your crops naturally. Learn to identify common pests and diseases affecting New Zealand farms.",
                ContentURL = "https://www.plantandfood.co.nz/page/agriculture/pest-management/",
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            },
            new EducationalContent
            {
                ContentID = 60,
                Title = "Climate Change Adaptation for Farmers",
                Description = "Prepare your farm for changing weather patterns and extreme events. Strategies for building resilience and adapting to climate variability.",
                ContentURL = "https://www.mpi.govt.nz/agriculture/climate-change/",
                CreatedAt = DateTime.UtcNow.AddDays(-12)
            },
            new EducationalContent
            {
                ContentID = 70,
                Title = "Direct Marketing and Farm-to-Table Sales",
                Description = "Learn how to sell directly to consumers and restaurants. Build relationships with local buyers and maximize your profit margins through direct sales.",
                ContentURL = "https://www.marketgardening.co.nz/direct-marketing/",
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            },
            new EducationalContent
            {
                ContentID = 80,
                Title = "Seasonal Planting Calendar for NZ",
                Description = "Month-by-month guide to planting vegetables and fruits in New Zealand. Optimize your growing seasons and plan for year-round production.",
                ContentURL = "https://www.gardening.co.nz/vegetables/planting-calendar/",
                CreatedAt = DateTime.UtcNow.AddDays(-8)
            },
            new EducationalContent
            {
                ContentID = 90,
                Title = "Farm Safety and Risk Management",
                Description = "Essential safety practices and risk management strategies for farm operations. Protect yourself, your workers, and your property.",
                ContentURL = "https://www.worksafe.govt.nz/topic-and-industry/agriculture/",
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new EducationalContent
            {
                ContentID = 100,
                Title = "Technology in Modern Farming",
                Description = "Explore how technology can improve farm efficiency and productivity. From GPS tractors to soil sensors, discover the latest agricultural innovations.",
                ContentURL = "https://www.agritech.org.nz/resources/",
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            }
        );

        builder.Entity<ShoppingCartItem>()
        .HasOne(sci => sci.FarmerProduct)
        .WithMany(fp => fp.ShoppingCartItems)
        .HasForeignKey(sci => sci.FarmerProductID)
        .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<PaymentDetail>()
            .HasOne(p => p.Order)
            .WithMany() // if Order doesn't have a collection of PaymentDetails
            .HasForeignKey(p => p.OrderID)
            .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete

        builder.Entity<OrderDetail>()
        .HasOne(od => od.Order)
        .WithMany(o => o.OrderDetails)
        .HasForeignKey(od => od.OrderID)
        .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Rating>()
     .HasOne(r => r.User)
     .WithMany(u => u.Ratings)
     .HasForeignKey(r => r.UserId) 
     .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Farmers>()
            .HasMany(f => f.FarmerProducts)
            .WithOne(p => p.Farmer)
            .HasForeignKey(p => p.FarmerID);

       

        builder.Entity<ShoppingCartItem>()
        .HasOne(sci => sci.FarmerProduct)
        .WithMany(fp => fp.ShoppingCartItems)
        .HasForeignKey(sci => sci.FarmerProductID)
        .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.User)
            .WithMany()  
            .HasForeignKey(sci => sci.UserID)
            .OnDelete(DeleteBehavior.Restrict);


    }

}
