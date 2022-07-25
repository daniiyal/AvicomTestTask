using AvicomTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvicomTestTask.DAL.Context
{
    public class SoftTradeDB : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<SubscriptionTime> SubscriptionTimes { get; set; }


        public DbSet<Order> Orders { get; set; }

        public DbSet<Status> Statuses { get; set; }


        public SoftTradeDB(DbContextOptions<SoftTradeDB> options) : base(options)

        {

        }

    }
}
