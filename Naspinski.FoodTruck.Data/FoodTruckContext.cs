using Naspinski.Data.CommandQuery.Interfaces;
using Naspinski.FoodTruck.Data.Models.Events;
using Naspinski.FoodTruck.Data.Models.Menu;
using Naspinski.FoodTruck.Data.Models.Payment;
using Naspinski.FoodTruck.Data.Models.Storage;
using Naspinski.FoodTruck.Data.Models.System;
using Microsoft.EntityFrameworkCore;
using Naspinski.FoodTruck.Data.Models.Specials;

namespace Naspinski.FoodTruck.Data
{
    public class FoodTruckContext : DbContext, IDbContext<FoodTruckContext>, IDbContext
    {
        public FoodTruckContext(DbContextOptions<FoodTruckContext> options)
            : base(options)
        { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ComboPart> ComboParts { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<DeliveryDestination> DeliveryDestinations { get; set; }
        public DbSet<Special> Specials { get; set; }
    }
}
