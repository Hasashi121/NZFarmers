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
