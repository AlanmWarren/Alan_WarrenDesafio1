using Alan_WarrenDesafio1.Data;
using Alan_WarrenDesafio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;

        public CustomerAppService(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            return _customerServices.GetAll(predicate);
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            return _customerServices.GetBy(predicate);
        }

        public bool Create(Customer newCustomer)
        {
            return _customerServices.Create(newCustomer);
        }

        public int Update(int id, Customer newCustomer)
        {
            return _customerServices.Update(id, newCustomer);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}

