using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;

        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            if (predicate is null) return _dataContext.Customers;

            var customers = _dataContext.Customers.Where(predicate);

            return customers;
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            var customer = _dataContext.Customers.AsNoTracking().FirstOrDefault(predicate);

            return customer;
        }

        public int Create(Customer newCustomer)
        {
            if (AnyCustomerForCpf(newCustomer) || AnyCustomerForEmail(newCustomer)) return -1;

            _dataContext.Customers.Add(newCustomer);
            _dataContext.SaveChanges();
            return newCustomer.Id;
        }

        public (bool status, string messageResult) Update(Customer customer)
        {
            var customerFound = GetBy(x => x.Id == customer.Id);
            if (customerFound is null) return (false, $"Customer not found for Id: {customer.Id}");

            (bool isEmailOrAndCpfExists, string message) = ValidateEmailAndCpfAlreadyExists(customerFound, customer);
            if (isEmailOrAndCpfExists) return (false, message);

            _dataContext.Update(customer);
            _dataContext.SaveChanges();

            return (true, $"Customer for ID: {customer.Id} updated successfully");
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetBy(x => x.Id == id);
            if (customerToDelete is null) return false;

            _dataContext.Remove(customerToDelete);
            _dataContext.SaveChanges();
            return true;
        }

        private bool AnyCustomerForEmail(Customer newCustomer) => _dataContext.Customers.Any(x => x.Email == newCustomer.Email);

        private bool AnyCustomerForCpf(Customer newCustomer) => _dataContext.Customers.Any(x => x.Cpf == newCustomer.Cpf);

        private (bool isExists, string message) ValidateEmailAndCpfAlreadyExists(Customer oldCustomer, Customer newCustomer)
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