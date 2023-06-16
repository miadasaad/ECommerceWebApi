using BLayer.DTOS.Customers;
using BLayer.Managers.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManger customerManger;
        public CustomersController(ICustomerManger _customerManger)
        {
            customerManger = _customerManger;
        }

        [HttpGet]
        public ActionResult<List<CustomerReadDto>> GetAll() {

            return customerManger.GetAll(); 
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerReadDto> Get(int id)
        {
            var customer = customerManger.GetById(id);
            if (customer == null) {
                return NotFound(); 
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult add(CustomerAddDto customerAddDto)
        {
            var newId = customerManger.Add(customerAddDto);
            return CreatedAtAction("Get", new { id = newId }, new { m = "customer has been added successfully" });
        }

        [HttpPut]
        public ActionResult update(CustomerUpdateDto customer)
        {
            var isFound = customerManger.Update(customer);
            if (isFound == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult delete(int id)
        {
            customerManger.Delete(id);
            return NoContent();
        }
    }
}
