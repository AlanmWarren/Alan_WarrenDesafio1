

using Alan_WarrenDesafio1.Models;

namespace Alan_WarrenDesafio1.Data
{
    public class DataCustomer : IDataCustomer
    {

        public List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                FullName = "Alan Martin Domingues",
                Email = "alanzuka@gmail.com",
                EmailConfirmation = "alanzuka@gmail.com",
                Cpf = "123.123.123-12",
                Cellphone = "47999999999",
                Birthdate = DateTime.Parse("25/05/2005"),
                EmailSms =  false,
                Whatsapp = true,
                Country = "Brasil",
                City = "Blumenau",
                PostalCode = "34545-123",
                Adress = "Rua Juliano Flores",
                Number = 117
            },
             new Customer()
            {
                Id = 2,
                FullName = "Sofia Almeida Júnior",
                Email = "joaozinho@hotmail.com",
                EmailConfirmation = "joaozinho@hotmail.com",
                Cpf = "321.321.321-32",
                Cellphone = "47948239734",
                Birthdate = DateTime.Parse("22/01/2007"),
                EmailSms =  false,
                Whatsapp = true,
                Country = "Brasil",
                City = "Joinville",
                PostalCode = "44346-163",
                Adress = "Rua XV de Novembro",
                Number = 212
            }
        };

        public void Add(Customer customerInput)
        {
            var LastId = Customers.Last().Id;
            customerInput.Id = LastId + 1;
            Customers.Add(customerInput);
        }

        public void Update(Customer customer, Customer customerInput)
        {
            customer.FullName = customerInput.FullName;
            customer.EmailConfirmation = customerInput.EmailConfirmation;
            customer.Cpf = customerInput.Cpf;
            customer.Cellphone = customerInput.Cellphone;
            customer.Birthdate = customerInput.Birthdate;
            customer.EmailSms = customerInput.EmailSms;
            customer.Whatsapp = customerInput.Whatsapp;
            customer.Country = customerInput.Country;
            customer.City = customerInput.City;
            customer.PostalCode = customerInput.PostalCode;
            customer.Adress = customerInput.Adress;
            customer.Number = customerInput.Number;  
        }
        
        public void Delete(Customer customer)
        {
            Customers.Remove(customer);
        }

        public bool VerifyEmail(Customer customer)
        {
            if (customer.Email == customer.EmailConfirmation) return true;

            return false;
        }
    }
}
