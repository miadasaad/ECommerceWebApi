using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public decimal totalPrice { get; set; }

        [ForeignKey("Customer")]  
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        [ForeignKey("Shipment")]
        public int ShipmentId { get; set; }

        public Payment? Payment { get; set; }
        public Shipment? Shipment { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
