﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZFarmers.Data;

#nullable disable

namespace NZFarmers.Migrations
{
    [DbContext(typeof(NZFarmersContext))]
    [Migration("20250401215529_RemovedUsersAndProductsModels")]
    partial class RemovedUsersAndProductsModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NZFarmers.Areas.Identity.Data.NZFarmersUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("NZFarmers.Models.DeliveryTracking", b =>
                {
                    b.Property<int>("TrackingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackingID"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("TrackingID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("DeliveryTrackings");
                });

            modelBuilder.Entity("NZFarmers.Models.EducationalContent", b =>
                {
                    b.Property<int>("ContentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentID"));

                    b.Property<string>("ContentURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ContentID");

                    b.ToTable("EducationalContents");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarketEvent", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EventID");

                    b.ToTable("FarmerMarketEvents");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarketParticipation", b =>
                {
                    b.Property<int>("FarmerID")
                        .HasColumnType("int");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int?>("FarmerMarketsEventID")
                        .HasColumnType("int");

                    b.Property<int>("ParticipationID")
                        .HasColumnType("int");

                    b.HasKey("FarmerID", "EventID");

                    b.HasIndex("EventID");

                    b.HasIndex("FarmerMarketsEventID");

                    b.ToTable("FarmerMarketParticipations");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarkets", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EventID");

                    b.ToTable("FarmerMarkets");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerProduct", b =>
                {
                    b.Property<int>("FarmerProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmerProductID"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FarmerID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("FarmerProductID");

                    b.HasIndex("FarmerID");

                    b.ToTable("FarmerProducts");
                });

            modelBuilder.Entity("NZFarmers.Models.Farmers", b =>
                {
                    b.Property<int>("FarmerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FarmName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("FarmerID");

                    b.HasIndex("UserID");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("NZFarmers.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"));

                    b.Property<int>("FarmerProductID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("FarmerProductID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("NZFarmers.Models.PaymentDetail", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PaymentID");

                    b.HasIndex("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("NZFarmers.Models.Rating", b =>
                {
                    b.Property<int>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingID"));

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FarmerID")
                        .HasColumnType("int");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RatingID");

                    b.HasIndex("FarmerID");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("NZFarmers.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FarmerProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ShoppingCartItemID");

                    b.HasIndex("FarmerProductID");

                    b.HasIndex("UserID");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NZFarmers.Models.DeliveryTracking", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithOne("DeliveryTracking")
                        .HasForeignKey("NZFarmers.Models.DeliveryTracking", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarketParticipation", b =>
                {
                    b.HasOne("NZFarmers.Models.FarmerMarketEvent", "FarmerMarketEvent")
                        .WithMany("FarmerMarketParticipations")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZFarmers.Models.Farmers", "Farmer")
                        .WithMany("FarmerMarketParticipations")
                        .HasForeignKey("FarmerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZFarmers.Models.FarmerMarkets", null)
                        .WithMany("FarmerMarketParticipations")
                        .HasForeignKey("FarmerMarketsEventID");

                    b.Navigation("Farmer");

                    b.Navigation("FarmerMarketEvent");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerProduct", b =>
                {
                    b.HasOne("NZFarmers.Models.Farmers", "Farmer")
                        .WithMany("FarmerProducts")
                        .HasForeignKey("FarmerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("NZFarmers.Models.Farmers", b =>
                {
                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NZFarmers.Models.OrderDetail", b =>
                {
                    b.HasOne("NZFarmers.Models.FarmerProduct", "FarmerProduct")
                        .WithMany("OrderDetails")
                        .HasForeignKey("FarmerProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FarmerProduct");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("NZFarmers.Models.PaymentDetail", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NZFarmers.Models.Rating", b =>
                {
                    b.HasOne("NZFarmers.Models.Farmers", "Farmer")
                        .WithMany("Ratings")
                        .HasForeignKey("FarmerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Farmer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NZFarmers.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("NZFarmers.Models.FarmerProduct", "FarmerProduct")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("FarmerProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FarmerProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("NZFarmers.Areas.Identity.Data.NZFarmersUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NZFarmers.Areas.Identity.Data.NZFarmersUser", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarketEvent", b =>
                {
                    b.Navigation("FarmerMarketParticipations");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerMarkets", b =>
                {
                    b.Navigation("FarmerMarketParticipations");
                });

            modelBuilder.Entity("NZFarmers.Models.FarmerProduct", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("NZFarmers.Models.Farmers", b =>
                {
                    b.Navigation("FarmerMarketParticipations");

                    b.Navigation("FarmerProducts");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("DeliveryTracking");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
