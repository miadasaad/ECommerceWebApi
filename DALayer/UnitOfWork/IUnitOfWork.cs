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
    public interface IUnitOfWork
    {
        public ICustomerRepo icustomerRepo { get; }
        public IProduct iproduct { get; }
        public IOrder iorder { get; }
        public IOrderProductRepo iOrderProductRepo { get; }

        public Icategory icategory { get; }
        int SaveChanges();
    }
}
