using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerServices customerServices, IMapper mapper)
        {
            _customerServices = customerServices;
            _mapper = mapper;
        }

        public IList<CustomerDto> GetAll(Func<Customer, bool> predicate = null)
        {
            var customers = _customerServices.GetAll(predicate);
            return _mapper.Map<IList<CustomerDto>>(customers);
        }

        public CustomerDto GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            return _mapper.Map<CustomerDto>(customer);
        }

        public int Create(CustomerDto newCustomerDto)
        {
            var newCustomer = _mapper.Map<Customer>(newCustomerDto);
            return _customerServices.Create(newCustomer);
        }

        public int Update(int id, CustomerDto customerToUpdateDto)
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

