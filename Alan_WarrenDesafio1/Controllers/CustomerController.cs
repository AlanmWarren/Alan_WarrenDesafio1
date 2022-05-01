using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alan_WarrenDesafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        public readonly IDataCustomer _datacustomer;
        public CustomerController(IDataCustomer dataCustomer)
        {
            _datacustomer = dataCustomer;
        }

        [HttpGet]
        public IActionResult Get()
        {           
            return Ok(_datacustomer.Customers);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var ctm = _datacustomer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("{fullname}")]
        public IActionResult GetByFullName(string fullName)
        {
            var ctm = _datacustomer.Customers.FirstOrDefault(c => c.FullName == fullName);
            if (ctm == null) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byFullName")]
        public IActionResult GetByFullNameByQueryString(string fullName)
        {
            var ctm = _datacustomer.Customers.FirstOrDefault(c => c.FullName == fullName);
            if (ctm == null) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (_datacustomer.VerifyEmail(customer))
            {
                _datacustomer.Add(customer);
                return Created("~api/customer", customer);
            }
            return BadRequest("Invalid email and email confirmation, please try again");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            var ctm = _datacustomer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            _datacustomer.Update(ctm, customer);
            return Ok(ctm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ctm = _datacustomer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            _datacustomer.Delete(ctm);
            return Ok("Customer successfully deleted");
        }
    }
}
