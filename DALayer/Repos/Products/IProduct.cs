using DALayer.Data.Models;
using DALayer.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.Products
{
    public interface IProduct:IGenericRepo<Product>
    {
        public List<Product> getProductsByCatId(int catId);
        public Product? getPrdByCategoryObject(int prdId);
    }
}
