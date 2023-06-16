using DALayer.Data.Models;
using DALayer.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.Customers
{
    public interface ICustomerRepo:IGenericRepo<Customer>
    {
    }
}
