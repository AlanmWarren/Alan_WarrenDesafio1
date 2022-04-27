

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
                //Birthdate = 
                EmailSms =  false,
                Whatsapp = true,
                Country = "Brasil",
                City = "Blumenau",
                PostalCode = "34545-123",
                Adress = "Rua Juliano Flores",
                Number = "222"
            }
        };

        public void Add(Customer customer)
        {
            new Customer()
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                EmailConfirmation = customer.EmailConfirmation,
                Cpf = customer.Cpf,
                Cellphone = customer.Cellphone,
                //Birthdate = customer.Birthdate,
                EmailSms = customer.EmailSms,
                Whatsapp = customer.Whatsapp,
                Country = customer.Country,
                City = customer.City,
                PostalCode = customer.PostalCode,
                Adress = customer.Adress,
                Number = customer.Number
            };
        }

        public bool Update(int id, Customer customer)
        {
            var ctm = Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return false;
            
            ctm.Id = customer.Id;
            ctm.FullName = customer.FullName;
            ctm.EmailConfirmation = customer.EmailConfirmation;
            ctm.Cpf = customer.Cpf;
            ctm.Cellphone = customer.Cellphone;
            ctm.EmailSms = customer.EmailSms;
            ctm.Whatsapp = customer.Whatsapp;
            ctm.Country = customer.Country;
            ctm.City = customer.City;
            ctm.PostalCode = customer.PostalCode;
            ctm.Adress = customer.Adress;
            ctm.Number = customer.Number;

            return true;

        }

        public bool Delete(int id)
        {
            var ctm = Customers.FirstOrDefault(c => c.Id == id);
            if (ctm == null) return false;
            Customers.Remove(ctm);
            return true;
        }

    }
}
