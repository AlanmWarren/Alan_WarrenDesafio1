using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();

        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            if (predicate is null) return _customers;

            var customers = _customers.Where(predicate);

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

        public (bool Status, string MessageResult) Update(Customer customer)
        {
            var indexOfCustomerToUpdate = _customers.FindIndex(x => x.Id == customer.Id);
            if (indexOfCustomerToUpdate == -1) return (false, $"Customer not found for Id: {customer.Id}");

            (bool isEmailOrAndCpfExists, string Message) = ValidateEmailAndCpfAlreadyExists(_customers[indexOfCustomerToUpdate], customer);
            if (isEmailOrAndCpfExists) return (false, Message);

            _customers[indexOfCustomerToUpdate] = customer;

            return (true, $"Customer for ID: {customer.Id} updated successfully");
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetBy(x => x.Id == id);
            if (customerToDelete is null) return false;

            return _customers.Remove(customerToDelete);
        }

        private bool AnyCustomerForEmail(Customer newCustomer) => _customers.Any(x => x.Email == newCustomer.Email);

        private bool AnyCustomerForCpf(Customer newCustomer) => _customers.Any(x => x.Cpf == newCustomer.Cpf);

        private (bool IsExists, string Message) ValidateEmailAndCpfAlreadyExists(Customer oldCustomer, Customer newCustomer)
        {
            if (newCustomer.Email != oldCustomer.Email)
            {
                if (AnyCustomerForEmail(newCustomer)) return (true, "'Email' already exists, please insert a new 'Email'");
            }

            if (newCustomer.Cpf != oldCustomer.Cpf)
            {
                if (AnyCustomerForCpf(newCustomer)) return (true, "'Cpf' already exists, please insert a new 'Cpf'");
            }

            return (false, "");
        }
    }
}