using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface ICustomerService
    {
        IList<Customer> GetAll(Func<Customer, bool> predicate = null);

        Customer GetBy(Func<Customer, bool> predicate);

        public int Create(Customer newCustomer);

        public (bool Status, string MessageResult) Update(int id, Customer newCustomer);

        public bool Delete(int id);
    }
}