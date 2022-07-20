using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null);

        Customer GetBy(Expression<Func<Customer, bool>> predicate);

        public int Create(Customer newCustomer);

        public (bool status, string messageResult) Update(Customer newCustomer);

        public bool Delete(int id);
    }
}