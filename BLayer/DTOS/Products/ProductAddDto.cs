using DALayer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DTOS.Products
{
    public class ProductAddDto
    {
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public int? quantity { get; set; }
        public string? imgUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

    }
}
