using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using Alan_WarrenDesafio1.Validators;
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
            var ctm = _datacustomer.Customers.FindAll(c => c.Id == id);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byFullName")]
        public IActionResult GetByFullName(string fullName)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.FullName == fullName);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byEmail")]
        public IActionResult GetByEmail(string email)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Email == email);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byCpf")]
        public IActionResult GetByCpf(string cpf)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Cpf == cpf);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byCellphone")]
        public IActionResult GetByCellphone(string cellphone)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Cellphone == cellphone);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byBirthdate")]
        public IActionResult GetByBirthdate(DateTime birthdate)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Birthdate == birthdate);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byEmailSms")]
        public IActionResult GetByEmailSms(bool emailSms)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.EmailSms == emailSms);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byWhatsapp")]
        public IActionResult GetByWhatsapp(bool whatsapp)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Whatsapp == whatsapp);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byCountry")]
        public IActionResult GetByCountry(string country)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Country == country);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byCity")]
        public IActionResult GetByCity(string city)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.City == city);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byPostalCode")]
        public IActionResult GetByPostalCode(string postalCode)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.PostalCode == postalCode);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byAdress")]
        public IActionResult GetByAdress(string adress)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Adress == adress);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpGet("byNumber")]
        public IActionResult GetByNumber(int number)
        {
            var ctm = _datacustomer.Customers.FindAll(c => c.Number == number);
            if (ctm.Count == 0) return NotFound("Customer not found");
            return Ok(ctm);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (CustomerValidator.ValidateEmail(customer))
            {
                _datacustomer.Create(customer);
                return Created("~api/customer", "Customer sucessfully registered with ID: " + customer.Id);
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
