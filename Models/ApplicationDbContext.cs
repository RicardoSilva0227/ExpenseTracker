﻿using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currency { get; set; }

    }
}
