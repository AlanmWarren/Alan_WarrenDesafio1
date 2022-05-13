

using Alan_WarrenDesafio1.Models;
using Alan_WarrenDesafio1.Validators;

namespace Alan_WarrenDesafio1.Data
{
    public class CustomerServices : ICustomerServices
    {
        private IList<Customer> Customers { get; set; } = new List<Customer>();

        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            if (predicate is null)
            {
                return Customers;
            }
            var customer = Customers.Where(predicate);

            return customer;
        }

        public Customer GetById(Func<Customer,bool> predicate)
        {
            var customer = Customers.FirstOrDefault(predicate);

            return customer is null
                ? null
                : customer;
        }

        public Customer GetByFullName(string fullName)
        {
            var customer = Customers.FirstOrDefault(x => x.FullName == fullName);

            return customer is null
                ? null
                : customer;
        }

        public Customer GetByEmail(string email)
        {
            var customer = Customers.FirstOrDefault(x => x.Email == email);

            return customer is null
                ? null
                : customer;
        }

        public Customer GetByCpf(string cpf)
        {
            var customer = Customers.FirstOrDefault(x => x.Cpf == cpf);

            return customer is null
                ? null
                : customer;
        }

        public bool Create(Customer newCustomer)
        {
            if (CustomerValidator.CustomerExists(newCustomer, Customers)) return false;

            if (Customers.Count == 0)
            {
                newCustomer.Id = 1;
                Customers.Add(newCustomer);
                return true;
            }
            else
            {
                var LastId = Customers.Last().Id;
                newCustomer.Id = LastId + 1;
                Customers.Add(newCustomer);
                return true;
            }
        }

        public int Update(int id, Customer newCustomer)
        {
            var customerToUpdate = GetById(x => x.Id == id);
            if (customerToUpdate is null) return 1;

            customerToUpdate.FullName = newCustomer.FullName;
            customerToUpdate.Email = newCustomer.Email;
            customerToUpdate.EmailConfirmation = newCustomer.EmailConfirmation;
            customerToUpdate.Cpf = newCustomer.FullName;
            customerToUpdate.Cellphone = newCustomer.Cellphone;
            customerToUpdate.EmailSms = newCustomer.EmailSms;
            customerToUpdate.Whatsapp = newCustomer.Whatsapp;
            customerToUpdate.Country = newCustomer.Country;
            customerToUpdate.City = newCustomer.City;
            customerToUpdate.PostalCode = newCustomer.PostalCode;
            customerToUpdate.Adress = newCustomer.Adress;
            customerToUpdate.Number = newCustomer.Number; 

            if (CustomerValidator.CustomerExists(customerToUpdate, Customers)) return 2;

            return 0;

        }

        public bool Delete(int id)
        {
            var customerToDelete = GetById(x => x.Id == id);
            return customerToDelete is not null
            && Customers.Remove(customerToDelete);
        }
    }
}
