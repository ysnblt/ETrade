using ETrade.Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dal
{
    public class TradeContext : DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> db) : base(db)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()
                .HasKey(b => new { b.Id, b.ProductId });     //compositeKey


        }
        public DbSet<City> City { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketMaster> BasketMaster { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products{ get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vat> Vat { get; set; }
    }
}

