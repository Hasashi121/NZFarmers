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
    public DbSet<DeliveryTracking> DeliveryTrackings { get; set; }
    public DbSet<EducationalContent> EducationalContents { get; set; }
    public DbSet<FarmerMarketEvent> FarmerMarketEvents { get; set; }
    public DbSet<FarmerMarketParticipation> FarmerMarketParticipations { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        builder.Entity<NZFarmersUser>().HasData(
    new NZFarmersUser
    {
        Id = "seed-user-1",
        UserName = "sarah@example.com",
        NormalizedUserName = "SARAH@EXAMPLE.COM",
        Email = "sarah@example.com",
        NormalizedEmail = "SARAH@EXAMPLE.COM",
        EmailConfirmed = true,
        PasswordHash = "PLACEHOLDER_HASH", // See below
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
    }
);

        builder.Entity<Farmers>().HasData(
        new Farmers
        {
            FarmerID = 3,
            UserID = "seed-user-1", // Must exist in AspNetUsers or seeded separately
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
            UserID = "seed-user-2", // Also must exist
            FarmName = "Sunny Fields",
            Description = "Locally sourced vegetables and fruits.",
            PhoneNumber = "+64287654321",
            ProfileImage = "https://example.com/images/farm2.jpg",
            Address = "456 Harvest Rd",
            City = "Christchurch",
            Region = "Canterbury",
            ZipCode = "8011"
        }
    );

        builder.Entity<FarmerProduct>().HasData(
    new FarmerProduct
    {
        FarmerProductID = 1,
        FarmerID = 2, // Sunny Fields
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
        FarmerID = 3, // Green Valley Farms
        ProductName = "Raw Clover Honey",
        Description = "Locally harvested honey from native bush.",
        Category = ProductCategory.Other,
        Price = 8.99m,
        Stock = 60,
        ImageURL = "https://example.com/images/honey.jpg"
    },
    new FarmerProduct
    {
        FarmerProductID = 4,
        FarmerID = 3,
        ProductName = "Free Range Eggs",
        Description = "Dozen of fresh free-range eggs.",
        Category = ProductCategory.Dairy,
        Price = 5.00m,
        Stock = 75,
        ImageURL = "https://example.com/images/eggs.jpg"
    }

);
        // Add this to your OnModelCreating method in NZFarmersContext.cs
        // Place this after your existing seed data for FarmerProduct

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
     .HasForeignKey(r => r.UserId) // Use UserId, not UserID
     .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Farmers>()
            .HasMany(f => f.FarmerProducts)
            .WithOne(p => p.Farmer)
            .HasForeignKey(p => p.FarmerID);

        builder.Entity<FarmerMarketParticipation>()
            .HasKey(fmp => new { fmp.FarmerID, fmp.EventID });

        builder.Entity<FarmerMarketParticipation>()
            .HasOne(fmp => fmp.Farmer)
            .WithMany(f => f.FarmerMarketParticipations)
            .HasForeignKey(fmp => fmp.FarmerID);

        builder.Entity<FarmerMarketParticipation>()
            .HasOne(fmp => fmp.FarmerMarketEvent)
            .WithMany(e => e.FarmerMarketParticipations)
            .HasForeignKey(fmp => fmp.EventID);

        builder.Entity<ShoppingCartItem>()
        .HasOne(sci => sci.FarmerProduct)
        .WithMany(fp => fp.ShoppingCartItems)
        .HasForeignKey(sci => sci.FarmerProductID)
        .OnDelete(DeleteBehavior.Restrict);


        // Similarly, if needed for ShoppingCartItem -> User
        builder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.User)
            .WithMany()  // or a collection if you want
            .HasForeignKey(sci => sci.UserID)
            .OnDelete(DeleteBehavior.Restrict);
    }

public DbSet<NZFarmers.Models.FarmerMarkets> FarmerMarkets { get; set; } = default!;
}
