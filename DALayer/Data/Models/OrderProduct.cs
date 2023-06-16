﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Data.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        
       
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
