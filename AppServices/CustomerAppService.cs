using Alan_WarrenDesafio1.DomainServices;
using Alan_WarrenDesafio1.DomainModels;
using Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerServices;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerService customerServices, IMapper mapper)
        {
            _customerServices = customerServices;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResult> GetAll(Func<Customer, bool> predicate = null)
        {
            var customers = _customerServices.GetAll(predicate);
            return _mapper.Map<IEnumerable<CustomerResult>>(customers);
        }

        public CustomerResult GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            return _mapper.Map<CustomerResult>(customer);
        }

        public int Create(CreateCustomerRequest newCustomerDto)
        {
            var newCustomer = _mapper.Map<Customer>(newCustomerDto);
            return _customerServices.Create(newCustomer);
        }

        public int Update(int id, UpdateCustomerRequest customerToUpdateDto)
        {
            var customerToUpdate = _mapper.Map<Customer>(customerToUpdateDto);
            return _customerServices.Update(id, customerToUpdate);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}