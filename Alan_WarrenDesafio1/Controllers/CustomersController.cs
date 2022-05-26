using Application.DTOs;
using AppServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
                return _customersAppService.GetAll(c => c.FullName.Contains(fullName)) is null
                    ? NotFound()
                    : Ok(_customersAppService.GetAll(c => c.FullName.Contains(fullName)));
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
        public IActionResult Post(CreateCustomerDto newCustomerDto)
        {
            return SafeAction(() =>
            {
                var customerId = _customersAppService.Create(newCustomerDto);

                return newCustomer is 0
                    ? BadRequest("Customer already exists, please insert a new customer")
                    : Created("~api/customer", $"New customer created with Id: {customerId}");
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCustomerDto preCustomerDto)
        {
            return SafeAction(() =>
            {
                var customerToUpdateProgressCode = _customersAppService.Update(id, preCustomerDto);

                if (customerToUpdateProgressCode == 1)
                    return NotFound();

                else if (customerToUpdateProgressCode == -1)
                    return BadRequest("Your information is already being used");

                else
                    return Ok($"Customer with ID: {id} updated successfully");

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