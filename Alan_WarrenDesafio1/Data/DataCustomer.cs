

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
                Cellphone = "47 96666-6666",
                Birthdate = new DateTime(2005,04,21),
                EmailSms =  false,
                Whatsapp = true,
                Country = "Brasil",
                City = "Blumenau",
                PostalCode = "34545-123",
                Adress = "Rua Juliano Flores",
                Number = 11
            }
        };

        public void Add(Customer customer)
        {
            var LastId = Customers.Last().Id;
            customer.Id = LastId + 1;
            Customers.Add(customer);
        }

        public void Update(Customer ctm, Customer customer)
        {
            ctm.FullName = customer.FullName;
            ctm.EmailConfirmation = customer.EmailConfirmation;
            ctm.Cpf = customer.Cpf;
            ctm.Cellphone = customer.Cellphone;
            ctm.Birthdate = customer.Birthdate;
            ctm.EmailSms = customer.EmailSms;
            ctm.Whatsapp = customer.Whatsapp;
            ctm.Country = customer.Country;
            ctm.City = customer.City;
            ctm.PostalCode = customer.PostalCode;
            ctm.Adress = customer.Adress;
            ctm.Number = customer.Number;
        }

        public bool Delete(int id)
        {
            var ctm = Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return false;
            Customers.Remove(ctm);
            return true;
        }

        public bool VerifyEmail(Customer customer)
        {
            if (customer.Email == customer.EmailConfirmation) return true;

            return false;
        }
    }
}
