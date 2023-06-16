using BLayer.DTOS.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Customers
{
    public interface ICustomerManger
    {
        public List<CustomerReadDto> GetAll();
        public CustomerReadDto? GetById(int id);
        public int Add(CustomerAddDto customerAddDto);
        public Boolean Update(CustomerUpdateDto customerUpdateDto);
        public void Delete(int id);
    }
}
