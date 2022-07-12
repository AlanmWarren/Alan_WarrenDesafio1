using System;

namespace Application.Models.Response
{
    public class CustomerResult
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string EmailConfirmation { get; private set; }
        public string Cpf { get; private set; }
        public string Cellphone { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool EmailSms { get; private set; }
        public bool Whatsapp { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Adress { get; private set; }
        public int Number { get; private set; }
    }
}