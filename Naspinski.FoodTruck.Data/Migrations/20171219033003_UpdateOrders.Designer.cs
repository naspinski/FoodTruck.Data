﻿// <auto-generated />
using Naspinski.FoodTruck.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Naspinski.FoodTruck.Data.Migrations
{
    [DbContext(typeof(FoodTruckContext))]
    [Migration("20171219033003_UpdateOrders")]
    partial class UpdateOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Begins");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("Ends");

                    b.Property<int>("LocationId");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Events.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SortOrder");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("MenuItemId");

                    b.Property<int?>("PriceTypeId");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("PriceTypeId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.PriceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SortOrder");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PriceTypes");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Payment.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsSandbox");

                    b.Property<string>("Note");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("TotalInCents");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Payment.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("OrderId");

                    b.Property<int>("PriceId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PriceId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Storage.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.System.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Events.Event", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Events.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.MenuItem", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Menu.Category", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.Price", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Menu.MenuItem", "MenuItem")
                        .WithMany("Prices")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Naspinski.FoodTruck.Data.Models.Menu.PriceType", "PriceType")
                        .WithMany("Prices")
                        .HasForeignKey("PriceTypeId");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Payment.OrderItem", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Payment.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Naspinski.FoodTruck.Data.Models.Menu.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
