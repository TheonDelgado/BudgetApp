using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Business" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Food" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Personal" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Other" });
        }
    }
}