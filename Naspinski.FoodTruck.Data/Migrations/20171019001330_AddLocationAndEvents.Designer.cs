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
    [Migration("20171019001330_AddLocationAndEvents")]
    partial class AddLocationAndEvents
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

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

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

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<DateTimeOffset?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuItems");
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
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Events.Location", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Events.Location")
                        .WithMany("Locations")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Naspinski.FoodTruck.Data.Models.Menu.MenuItem", b =>
                {
                    b.HasOne("Naspinski.FoodTruck.Data.Models.Menu.Category", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
