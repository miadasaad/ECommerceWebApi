using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public int? quantity { get; set; }
        public string? imgUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }= new HashSet<OrderProduct>();

        public ICollection<Cart> Cart { get; set; } = new HashSet<Cart>();
    }
}
