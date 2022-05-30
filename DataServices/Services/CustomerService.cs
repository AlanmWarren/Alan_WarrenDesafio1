using Alan_WarrenDesafio1.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alan_WarrenDesafio1.DomainServices
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> Customers = new();

        public IList<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            if (predicate is null) return Customers;

            var customers = Customers.Where(predicate).ToList();

            return customers;
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            var customer = Customers.FirstOrDefault(predicate);

            return customer;
        }

        public int Create(Customer newCustomer)
        {
            if (CustomerExists(newCustomer, Customers)) return 0;

            int autoIncrementId = Customers.LastOrDefault()?.Id ?? default;

            newCustomer.Id = autoIncrementId + 1;
            Customers.Add(newCustomer);
            return newCustomer.Id;
        }

        public int Update(int id, Customer newCustomer)
        {
            var customerToUpdate = GetBy(x => x.Id == id);

            if (customerToUpdate is null) return 1;

            if (CustomerExists(newCustomer, Customers)) return -1;

            var indexOfCustomerToUpdate = Customers.IndexOf(customerToUpdate);
            newCustomer.Id = id;
            Customers[indexOfCustomerToUpdate] = newCustomer;

            return 0;
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetBy(x => x.Id == id);
            return customerToDelete is not null
            && Customers.Remove(customerToDelete);
        }

        private static bool CustomerExists(Customer newCustomer, IList<Customer> customers)
        {
            return customers.Any(x => x.Email == newCustomer.Email || x.Cpf == newCustomer.Cpf);
        }
    }
}