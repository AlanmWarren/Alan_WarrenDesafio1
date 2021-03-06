using Application.Models.Requests;
using Application.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Services;

namespace Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerServices;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerService customerServices, IMapper mapper)
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResult> GetAll(Func<Customer, bool> predicate = null)
        {
            var customers = _customerServices.GetAll(predicate);
            var result = _mapper.Map<IEnumerable<CustomerResult>>(customers);
            return result;
        }

        public CustomerResult GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            var result = _mapper.Map<CustomerResult>(customer);
            return result;
        }

        public int Create(CreateCustomerRequest newCustomerDto)
        {
            var customer = _mapper.Map<Customer>(newCustomerDto);
            return _customerServices.Create(customer);
        }

        public (bool status, string messageResult) Update(int id, UpdateCustomerRequest customerToUpdateDto)
        {
            var customerToUpdate = _mapper.Map<Customer>(customerToUpdateDto);
            customerToUpdate.Id = id;
            return _customerServices.Update(customerToUpdate);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}