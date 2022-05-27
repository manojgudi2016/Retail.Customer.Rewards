using Microsoft.EntityFrameworkCore;
using System;
using Retail.Customer.Rewards.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Retail.Customer.Rewards.Data
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions<DataContext> _options;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Retail.Customer.Rewards.Data.Entities.Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Retail.Customer.Rewards.Data.Entities.Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel>().HasKey(x => x.Id);
            modelBuilder.Entity<Retail.Customer.Rewards.Data.Entities.Transaction>().HasKey(x => x.Id);
        }

        public DbSet<Retail.Customer.Rewards.Data.Entities.Customer> Customers { get; set; }

        public DbSet<Retail.Customer.Rewards.Data.Entities.Product> Products { get; set; }

        //This can be driven from applications settings too as an alternative
        public DbSet<Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel> RewardThresholdLevels { get; set; }

        public DbSet<Retail.Customer.Rewards.Data.Entities.Transaction> Transactions { get; set; }

        public void AddOrUpdateSeedData()
        {
            Seed.AddOrUpdateSeedData(this);
        }
    }
    //Seed
    public static class Seed
    {
        internal static DataContext AddOrUpdateSeedData(this DataContext dataContext)
        {
            List<Retail.Customer.Rewards.Data.Entities.Customer> customers = new List<Retail.Customer.Rewards.Data.Entities.Customer>()
            {
                new Retail.Customer.Rewards.Data.Entities.Customer()
                {
                    FirstName ="Manoj",
                    LastName= "Reddy",
                    Email ="manojreddy@gmail.com",
                    PhoneNumber ="9876543210"
                },
                new Retail.Customer.Rewards.Data.Entities.Customer()
                {
                    FirstName ="Customer2",
                    LastName= "Ln",
                    Email ="customer2@gmail.com",
                    PhoneNumber ="9876543211"
                },
                new Retail.Customer.Rewards.Data.Entities.Customer()
                {
                    FirstName ="Customer3",
                    LastName= "Lastn",
                    Email ="customer3@gmail.com",
                    PhoneNumber ="9876543212"
                }
            };
            foreach (var customer in customers)
            {
                if (!dataContext.Customers.Any(x => x.Email == customer.Email))
                {
                    dataContext.Customers.AddAsync(customer);
                    dataContext.SaveChanges();
                }
            }


            List<Retail.Customer.Rewards.Data.Entities.Product> products = new List<Retail.Customer.Rewards.Data.Entities.Product>()
            {
                new Retail.Customer.Rewards.Data.Entities.Product()
                {
                    Category="Electronics",
                    Name="WashingMachine",
                    Price =600.00M
                },
                new Retail.Customer.Rewards.Data.Entities.Product()
                {
                    Category="Electronics",
                    Name="Refrigerator",
                    Price =1850.00M
                },
                new Retail.Customer.Rewards.Data.Entities.Product()
                {
                    Category="Electronics",
                    Name="Laptop",
                    Price =950.00M
                },
                new Retail.Customer.Rewards.Data.Entities.Product()
                {
                    Category="HomeDecor",
                    Name="Wall Clock",
                    Price =25.99M
                }
            };
            foreach (var product in products)
            {
                if (!dataContext.Products.Any(x => x.Name == product.Name))
                {
                    dataContext.Products.AddAsync(product);
                    dataContext.SaveChanges();
                }
            }

            List<Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel> rewards = new List<Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel>()
            {
                new Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel()
                {
                    Level ="Level1",
                    Threshold =50.00M,
                    isActive =true,
                    RewardPoint =1
                },
                new Retail.Customer.Rewards.Data.Entities.RewardThresholdLevel()
                {
                    Level ="Level2",
                    Threshold =100.00M,
                    isActive =true,
                    RewardPoint =1
                }
            };
            foreach (var reward in rewards)
            {
                if (!dataContext.RewardThresholdLevels.Any(x => x.Level == reward.Level))
                {
                    dataContext.RewardThresholdLevels.AddAsync(reward);
                    dataContext.SaveChanges();
                }
            }
            return dataContext;
        }
    }
}
