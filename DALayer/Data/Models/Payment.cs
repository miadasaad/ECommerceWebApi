using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string? MethodType { get; set; }
        public decimal amount { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();
    }
}
