using BLayer.DTOS.Customers;
using DALayer.Data.Models;
using DALayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Customers
{
    public class CustomerManager:ICustomerManger
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerManager(IUnitOfWork _unitOfWork) {
            unitOfWork = _unitOfWork;
        }

        public int Add(CustomerAddDto customerAddDto)
        {
            var customer = new Customer { 
                Address= customerAddDto.Address,
                name=customerAddDto.name ,
                Phone= customerAddDto.Phone};

            unitOfWork.icustomerRepo.add(customer);
            unitOfWork.SaveChanges();

            return customer.Id;
        }

        public void Delete(int id)
        {
            var customer = unitOfWork.icustomerRepo.GetById(id);
            if (customer == null)
            {
                return;  
            }
            unitOfWork.icustomerRepo.remove(id);
            unitOfWork.SaveChanges();
            
        }

        public List<CustomerReadDto> GetAll()
        {
            IEnumerable<Customer> customers = unitOfWork.icustomerRepo.GetAll();
            return customers.Select(d => new CustomerReadDto
            {
                Id = d.Id,
                name = d.name ,
                Address = d.Address ,
                Phone = d.Phone
            }).ToList();
            
        }

        public CustomerReadDto? GetById(int id)
        {
            var customer= unitOfWork.icustomerRepo.GetById(id);
            if (customer == null) { return null; }
            return new CustomerReadDto
            {
                Id = customer.Id ,
                name = customer.name ,
                Address = customer.Address ,
                Phone = customer.Phone 
            };
        }

        public Boolean Update(CustomerUpdateDto customerUpdateDto)
        {
            var customer = unitOfWork.icustomerRepo.GetById(customerUpdateDto.Id);
            if (customer == null) { return false; }
            customer.Address = customerUpdateDto.Address;
            customer.Phone = customerUpdateDto.Phone;
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
