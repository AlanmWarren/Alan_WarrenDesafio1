using Alan_WarrenDesafio1.Models;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IList<CustomerDto> GetAll(Func<Customer, bool> predicate = null);

        CustomerDto GetBy(Func<Customer, bool> predicate);

        public int Create(CustomerDto newCustomerDto);

        public int Update(int id, CustomerDto customerToUpdateDto);

        public bool Delete(int id);
    }
}

