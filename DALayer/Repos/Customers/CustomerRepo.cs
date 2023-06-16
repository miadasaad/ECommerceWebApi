using DALayer.Data.Context;
using DALayer.Data.Models;
using DALayer.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.Customers
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(ECommerceDb _context) : base(_context)
        {
        }
    }
}
