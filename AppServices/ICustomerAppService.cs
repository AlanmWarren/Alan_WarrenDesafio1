using Alan_WarrenDesafio1.Models;
using Application.DTOs;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IEnumerable<ReadCustomerDto> GetAll(Func<Customer, bool> predicate = null);

        ReadCustomerDto GetBy(Func<Customer, bool> predicate);

        public int Create(CreateCustomerDto newCustomerDto);

        public int Update(int id, UpdateCustomerDto customerToUpdateDto);

        public bool Delete(int id);
    }
}

