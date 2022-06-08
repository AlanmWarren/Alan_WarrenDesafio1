using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();

        public IList<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            if (predicate is null) return _customers;

            var customers = _customers.Where(predicate).ToList();

            return customers;
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customers.FirstOrDefault(predicate);

            return customer;
        }

        public int Create(Customer newCustomer)
        {
            if (AnyCustomerForCpf(newCustomer) || AnyCustomerForEmail(newCustomer)) return -1;

            int newId = _customers.LastOrDefault()?.Id ?? default;

            newCustomer.Id = newId + 1;
            _customers.Add(newCustomer);
            return newCustomer.Id;
        }

        public (bool Status, string MessageResult) Update(int id, Customer newCustomer)
        {
            var indexOfCustomerToUpdate = _customers.FindIndex(x => x.Id == id);

            if (indexOfCustomerToUpdate == -1) return (false, "Customer invalid");

            if (newCustomer.Email != _customers[indexOfCustomerToUpdate].Email && newCustomer.Cpf != _customers[indexOfCustomerToUpdate].Cpf)
                if (AnyCustomerForEmail(newCustomer)) return (false, "'Email' and 'Cpf' already exists, please insert a new 'Email' and 'Cpf'");

            if (newCustomer.Email != _customers[indexOfCustomerToUpdate].Email)
                if (AnyCustomerForEmail(newCustomer)) return (false, "'Email' already exists, please insert a new 'Email'");

            if (newCustomer.Cpf != _customers[indexOfCustomerToUpdate].Cpf)
                if (AnyCustomerForCpf(newCustomer)) return (false, "'Cpf' already exists, please insert a new 'Cpf'");

            newCustomer.Id = id;
            _customers[indexOfCustomerToUpdate] = newCustomer;

            return (true, $"Customer with ID: {id} updated successfully");
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetBy(x => x.Id == id);

            return _customers.Remove(customerToDelete);
        }

        private bool AnyCustomerForEmail(Customer newCustomer) => _customers.Any(x => x.Email == newCustomer.Email);

        private bool AnyCustomerForCpf(Customer newCustomer) => _customers.Any(x => x.Cpf == newCustomer.Cpf);
    }
}