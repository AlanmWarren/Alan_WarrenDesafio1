using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using AppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alan_WarrenDesafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customersAppService;
        public CustomersController(ICustomerAppService customerAppService)
        {
            _customersAppService = customerAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return SafeAction(() =>
            {
                var customers = _customersAppService.GetAll();

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
                return _customersAppService.GetBy(c => c.Id == id) is null
                ? NotFound()
                : Ok(_customersAppService.GetBy(c => c.Id == id));
            });
        }

        [HttpGet("byFullName")]
        public IActionResult GetByFullName(string fullName)
        {
            return SafeAction(() =>
            {
                return _customersAppService.GetAll(c => c.FullName == fullName) is null
                    ? NotFound()
                    : Ok(_customersAppService.GetAll(c => c.FullName == fullName));
            });
        }

        [HttpGet("byEmail")]
        public IActionResult GetByEmail(string email)
        {
            return SafeAction(() =>
            {
                return _customersAppService.GetBy(c => c.Email == email) is null
                    ? NotFound()
                    : Ok(_customersAppService.GetBy(c => c.Email == email));
            });
        }

        [HttpGet("byCpf")]
        public IActionResult GetByCpf(string cpf)
        {
            return SafeAction(() =>
            {
                return _customersAppService.GetBy(c => c.Cpf == cpf) is null
                    ? NotFound()
                    : Ok(_customersAppService.GetBy(c => c.Cpf == cpf));
            });
        }

        [HttpPost]
        public IActionResult Post(Customer newCustomer)
        {
            return SafeAction(() =>
            {
                return _customersAppService.Create(newCustomer)
                    ? Created("~api/customer", $"ID: {newCustomer.Id} Created")
                    : BadRequest("Customer already exists, please insert a new customer");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer preCustomer)
        {
            return SafeAction(() =>
            {
                var customerToChangeProgressCode = _customersAppService.Update(id, preCustomer);

                if (customerToChangeProgressCode == 1)
                {
                    return NotFound();
                }
                else if (customerToChangeProgressCode == 2)
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
                return !_customersAppService.Delete(id)
                    ? NotFound()
                    : NoContent();
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