using BLayer.DTOS.Categories;
using DALayer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DTOS.Products
{
    public class ProductWithCategory
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public string? imgUrl { get; set; }
        public int catId { get; set; }
        public CategoryReadDto category { get; set; }
    }
}
