using DALayer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Context
{
    public class ECommerceDb:DbContext
    {
        public ECommerceDb(DbContextOptions options):base(options)
        {

        }
        public DbSet<Cart> Cart => Set<Cart>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<OrderProduct> OrderProduct => Set<OrderProduct>();
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<Payment> Payment => Set<Payment>();
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Shipment> Shipment => Set<Shipment>();
        public DbSet<Brand> Brand => Set<Brand>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //order-product table
            modelBuilder.Entity<OrderProduct>()
            .HasOne(t => t.Orders)
            .WithMany(t => t.OrderProducts)
            .HasForeignKey(t => t.OrdersId);

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(t => t.Product)
                        .WithMany(t => t.OrderProducts)
                        .HasForeignKey(t => t.ProductId);
            //cart table:: customer with product
            modelBuilder.Entity<Cart>()
            .HasOne(t => t.Customer)
            .WithMany(t => t.Cart)
            .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Cart>()
                        .HasOne(t => t.Product)
                        .WithMany(t => t.Cart)
                        .HasForeignKey(t => t.ProductId);

            modelBuilder.Entity<Orders>()
                .HasOne(b => b.Customer)
                .WithMany(a => a.Orders)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shipment>()
                .HasOne(b => b.Customer)
                .WithMany(a => a.Shipment)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
