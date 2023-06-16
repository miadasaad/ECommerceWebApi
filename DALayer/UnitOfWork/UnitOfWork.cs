using DALayer.Data.Context;
using DALayer.Repos.Categories;
using DALayer.Repos.Customers;
using DALayer.Repos.Order;
using DALayer.Repos.OrderProducts;
using DALayer.Repos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepo icustomerRepo { get; }

        public IProduct iproduct { get; }

        public IOrder iorder { get; }

        public IOrderProductRepo iOrderProductRepo { get; }

        public Icategory icategory { get; }

        private readonly ECommerceDb context;
        public UnitOfWork(ICustomerRepo icustomerRepo, IProduct iproduct, IOrder iorder, IOrderProductRepo iOrderProductRepo,Icategory _icategory,ECommerceDb _context)
        {
            this.icustomerRepo = icustomerRepo;
            this.iproduct = iproduct;
            this.iorder = iorder;
            this.iOrderProductRepo = iOrderProductRepo;
            icategory = _icategory;
            context = _context;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
