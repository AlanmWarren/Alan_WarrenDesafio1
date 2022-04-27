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
            if (ctm == null) return BadRequest();            
            return Ok(ctm);
        }


        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            _datacostumer.Add(customer);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            if (_datacostumer.Update(id, customer))
            {
                return Ok(customer);
            }
            return BadRequest("Pessoa não encontrada");
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
                return Ok();
            }
            return BadRequest("Pessoa não encontrada");
        }

    }
}
