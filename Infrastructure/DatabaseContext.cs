using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            this.Database.CommandTimeout = 3600;
        }

        public DbSet<Products> Products { get; set; }
    }
}
