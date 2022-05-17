using Alan_WarrenDesafio1.Models;
using System;
using System.Collections.Generic;

namespace Alan_WarrenDesafio1.Data
{
    public interface ICustomerServices
    {
        IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null);
        Customer GetBy(Func<Customer, bool> predicate);
        public bool Create(Customer newCustomer);
        public int Update(int id, Customer newCustomer);
        public bool Delete(int id);

    }
}