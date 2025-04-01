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
