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

        public readonly IDataCustomer _datacostumer;
        public CustomerController(IDataCustomer dataCustomer)
        {
            _datacostumer = dataCustomer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_datacostumer.Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ctm = _datacostumer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            return Ok(ctm);
        }
        [HttpGet("byid")]
        public IActionResult GetByIdQS(int id)
        {
            var ctm = _datacostumer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (_datacostumer.VerifyEmail(customer))
            {
                _datacostumer.Add(customer);
                return Created("~api/customer", customer);
            }
            return NotFound("Invalid email and email confirmation, please try again");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            var ctm = _datacostumer.Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return NotFound("Customer not found");
            _datacostumer.Update(ctm, customer);
            return Ok(ctm);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Customer customer)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_datacostumer.Delete(id))
            {
                return Ok("Customer successfully deleted");
            }
            return NotFound("Customer not found");
        }
        //Falta o Birthdate, number e talvez o patch também 
    }
}
