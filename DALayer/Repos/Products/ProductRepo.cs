using DALayer.Data.Context;
using DALayer.Data.Models;
using DALayer.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.Products
{
    public class ProductRepo : GenericRepo<Product>, IProduct
    {
        private readonly ECommerceDb context;
        public ProductRepo(ECommerceDb _context) : base(_context)
        {
            context = _context;
        }

        public Product? getPrdByCategoryObject(int prdId)
        {
            return context.Product.Include(b => b.Category).FirstOrDefault(b => b.Id == prdId);
        }

        public List<Product> getProductsByCatId(int catId)
        {
            return context.Product.Where(item => item.CategoryId == catId).ToList();
        }
    }
}
