using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }


        public ICollection<Cart> Cart { get; set; } = new HashSet<Cart>();
        public ICollection<Shipment> Shipment { get; set; } = new HashSet<Shipment>();
        public ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();
        public ICollection<Payment> Payment { get; set; } = new HashSet<Payment>();
    }
}
