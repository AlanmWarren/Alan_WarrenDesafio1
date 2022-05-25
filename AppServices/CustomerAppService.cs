using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using Application.DTOs;
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

        public IEnumerable<ReadCustomerDto> GetAll(Func<Customer, bool> predicate = null)
        {
            var customers = _customerServices.GetAll(predicate);

            return customers is not null
                ? _mapper.Map<IEnumerable<ReadCustomerDto>>(customers)
                : null;
        }

        public ReadCustomerDto GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            return _mapper.Map<ReadCustomerDto>(customer);
        }

        public int Create(CreateCustomerDto newCustomerDto)
        {
            var newCustomer = _mapper.Map<Customer>(newCustomerDto);
            return _customerServices.Create(newCustomer);
        }

        public int Update(int id, UpdateCustomerDto customerToUpdateDto)
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

