using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
       
        public int ProductId { get; set; }
        public int quantity { get; set; }
        public Product? Product { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
