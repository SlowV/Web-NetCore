using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebNetCore.Models
{
    public class WebModelContext : DbContext
    {
        public WebModelContext(DbContextOptions<WebModelContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(b => b.Created_At)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Product>()
                .Property(c => c.Updated_At)
                .HasDefaultValueSql("getdate()");
        }
    }
}
