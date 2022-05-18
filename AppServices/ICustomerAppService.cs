using Alan_WarrenDesafio1.Models;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null);

        public Customer GetBy(Func<Customer, bool> predicate);

        public bool Create(Customer newCustomer);

        public int Update(int id, Customer newCustomer);

        public bool Delete(int id);
    }
}

