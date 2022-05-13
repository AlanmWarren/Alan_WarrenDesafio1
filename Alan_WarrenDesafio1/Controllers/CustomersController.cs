using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using Alan_WarrenDesafio1.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alan_WarrenDesafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly ICustomerServices _customersServices;
        public CustomersController(ICustomerServices customerServices)
        {
            _customersServices = customerServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return SafeAction(() =>
            {
                var customers = _customersServices.GetAll();

                return !customers.Any()
                    ? NotFound()
                    : Ok(customers);
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return SafeAction(() =>
            {
                return _customersServices.GetById(x => x.Id == id) is null
                ? NotFound()
                : Ok(_customersServices.GetById(x => x.Id == id));
            });
        }

        [HttpGet("byFullName")]
        public IActionResult GetByFullFullName(string fullName)
        {
            return SafeAction(() =>
            {
                return _customersServices.GetByFullName(fullName) is null
                    ? NotFound()
                    : Ok(_customersServices.GetByFullName(fullName));
            });
        }

        [HttpGet("byEmail")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                return _customersServices.GetByEmail(email) is null
                    ? NotFound()
                    : Ok(_customersServices.GetByEmail(email));
            });
        }

        [HttpGet("byCpf")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                return _customersServices.GetByCpf(cpf) is null
                    ? NotFound()
                    : Ok(_customersServices.GetByCpf(cpf));
            });
        }

        [HttpPost]
        public IActionResult Post(Customer newCustomer)
        {
            return SafeAction(() =>
            {
                return _customersServices.Create(newCustomer) is true
                    ? Created("~api/customer", $"ID: {newCustomer.Id} Created")
                    : BadRequest("Customer already exists, please insert a new customer");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer preCustomer)
        {
            return SafeAction(() =>
            {
                var customerChangedCode = _customersServices.Update(id, preCustomer);
                if (customerChangedCode == 1)
                {
                    return NotFound();
                }
                else if (customerChangedCode == 2)
                {
                    return BadRequest("Your information is already being used");
                }
                else
                {
                    return Ok($"Customer with ID : {id} changed successfully");
                }
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return SafeAction(() =>
            {
                return _customersServices.Delete(id) is false
                    ? NotFound()
                    : Ok("Customer successfully deleted");
            });
        }

        private IActionResult SafeAction(Func<IActionResult> action)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
