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

            modelBuilder.Entity<Transaction>(transaction =>
            {
                transaction.HasKey(t => t.Id);

                transaction.HasOne(t => t.Category)
                    .WithMany()
                    .HasForeignKey(t => t.CategoryId)
                    .HasPrincipalKey(c => c.Id);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(c => c.Id);
            });
            
            
            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Business" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Food" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Personal" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, CategoryName = "Other" });
        }
    }
}