using Alan_WarrenDesafio1.DomainModels;
using Application.DTOs;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResult> GetAll(Func<Customer, bool> predicate = null);

        CustomerResult GetBy(Func<Customer, bool> predicate);

        public int Create(CreateCustomerRequest newCustomerDto);

        public int Update(int id, UpdateCustomerRequest customerToUpdateDto);

        public bool Delete(int id);
    }
}