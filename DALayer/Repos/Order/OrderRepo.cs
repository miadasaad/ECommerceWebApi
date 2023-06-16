﻿using DALayer.Data.Context;
using DALayer.Data.Models;
using DALayer.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.Order
{
    public class OrderRepo : GenericRepo<Orders>, IOrder
    {
        public OrderRepo(ECommerceDb _context) : base(_context)
        {
        }
    }
}
