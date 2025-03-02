using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Models;
using System.Reflection.Emit;

namespace NZFarmers.Data;

public class NZFarmersContext : IdentityDbContext<NZFarmersUser>
{
    public NZFarmersContext(DbContextOptions<NZFarmersContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Farmers> Farmers { get; set; }
    public DbSet<FarmersLocation> FarmerLocations { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<FarmerProduct> FarmerProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<OrderPayment> OrderPayments { get; set; }
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
        builder.Entity<OrderDetail>()
        .HasOne(od => od.Order)
        .WithMany(o => o.OrderDetails)
        .HasForeignKey(od => od.OrderID)
        .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<OrderPayment>()
        .HasOne(op => op.PaymentDetail)
        .WithMany(pd => pd.OrderPayments)
        .HasForeignKey(op => op.PaymentID)
        .OnDelete(DeleteBehavior.Restrict);

        // You may also need to configure other relationships that might cause multiple cascade paths
        // For example, if OrderPayments also relates to Orders:
        builder.Entity<OrderPayment>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderPayments)
            .HasForeignKey(op => op.OrderID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Rating>()
        .HasOne(r => r.User)
        .WithMany(u => u.Ratings)
        .HasForeignKey(r => r.UserID)
        .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Farmers>()
           .HasMany(f => f.FarmerLocations)
           .WithOne(l => l.Farmer)
           .HasForeignKey(l => l.FarmerID);

        builder.Entity<Farmers>()
            .HasMany(f => f.FarmerProducts)
            .WithOne(p => p.Farmer)
            .HasForeignKey(p => p.FarmerID);

        // Configuring Many-to-Many Relationships using Fluent API
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
    }
}
