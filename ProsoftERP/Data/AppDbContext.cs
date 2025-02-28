﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProsoftERP.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=prosofterp.db");
        }
    }
}
