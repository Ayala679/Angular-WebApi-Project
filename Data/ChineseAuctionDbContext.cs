using Chinese_Auction.Data;
using Chinese_Auction.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
//using Microsoft.EntityFrameworkCore;

namespace Chinese_Auction.Data
{
    public class ChineseAuctionDbContext : DbContext
    {
        public ChineseAuctionDbContext(DbContextOptions<ChineseAuctionDbContext> options) : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Donor> Donors => Set<Donor>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Gift> Gifts => Set<Gift>();
        public DbSet<Purchase> Purchases => Set<Purchase>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // מפות שמות הטבלאות במסד הנתונים
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Donor>().ToTable("Donors");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Gift>().ToTable("Gifts");
            modelBuilder.Entity<Purchase>().ToTable("Purchases");

            base.OnModelCreating(modelBuilder);
        }

    }
}
