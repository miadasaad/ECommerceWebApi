﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DTOS.Customers
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
