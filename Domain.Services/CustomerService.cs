using Domain.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null)
        {
            var repository = _unitOfWork.Repository<Customer>();

            if (predicate is null)
            {
                var query = repository.MultipleResultQuery();

                var result = repository.Search(query);

                return result;
            }

            var queryFiltered = repository.MultipleResultQuery()
                                          .AndFilter(predicate);

            var resultFiltered = repository.Search(queryFiltered);

            return resultFiltered;
        }

        public Customer GetBy(Expression<Func<Customer, bool>> predicate)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var query = repository.SingleResultQuery()
                                  .AndFilter(predicate);

            var result = repository.FirstOrDefault(query);

            return result;
        }

        public int Create(Customer newCustomer)
        {
            if (AnyCustomerForCpf(newCustomer) || AnyCustomerForEmail(newCustomer))
            {
                _unitOfWork.Rollback();
                return -1;
            }

            var repository = _unitOfWork.Repository<Customer>();

            repository.Add(newCustomer);
            _unitOfWork.SaveChanges();

            return newCustomer.Id;
        }

        public (bool status, string messageResult) Update(Customer customer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var customerFound = GetBy(x => x.Id == customer.Id);
            if (customerFound is null) return (false, $"Customer not found for Id: {customer.Id}");

            (bool exists, string message) = ValidateEmailAndCpfAlreadyExists(customerFound, customer);
            if (exists)
            {
                _unitOfWork.Rollback();
                return (false, message);
            }

            repository.Update(customer);
            _unitOfWork.SaveChanges();

            return (true, $"Customer for ID: {customer.Id} updated successfully");
        }

        public bool Delete(int id)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var customerToDelete = GetBy(x => x.Id == id);
            if (customerToDelete is null)
            {
                _unitOfWork.Rollback();
                return false;
            }

            repository.Remove(customerToDelete);
            _unitOfWork.SaveChanges();

            return true;
        }

        private bool AnyCustomerForEmail(Customer newCustomer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            return repository.Any(x => x.Email == newCustomer.Email);
        }

        private bool AnyCustomerForCpf(Customer newCustomer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            return repository.Any(x => x.Cpf == newCustomer.Cpf);
        }

        private (bool exists, string message) ValidateEmailAndCpfAlreadyExists(Customer oldCustomer, Customer newCustomer)
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