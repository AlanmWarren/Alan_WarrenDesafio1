using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null);

        Customer GetBy(Func<Customer, bool> predicate);

        public int Create(Customer newCustomer);

        public (bool Status, string MessageResult) Update(Customer newCustomer);

        public bool Delete(int id);
    }
}