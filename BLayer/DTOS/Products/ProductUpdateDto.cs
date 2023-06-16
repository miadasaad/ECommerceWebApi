using DALayer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DTOS.Products
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public int? quantity { get; set; }

    }
}
