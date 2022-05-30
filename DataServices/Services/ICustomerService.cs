using Alan_WarrenDesafio1.DomainModels;
using System;
using System.Collections.Generic;

namespace Alan_WarrenDesafio1.DomainServices
{
    public interface ICustomerService
    {
        IList<Customer> GetAll(Func<Customer, bool> predicate = null);

        Customer GetBy(Func<Customer, bool> predicate);

        public int Create(Customer newCustomer);

        public int Update(int id, Customer newCustomer);

        public bool Delete(int id);
    }
}