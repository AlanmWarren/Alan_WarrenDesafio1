namespace Alan_WarrenDesafio1.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public Customer(int id, string fullName, string email, string emailConfirmation, string cpf, string cellphone, /*DateOnly birthdate,*/
            bool emailSms, bool whatsapp, string country, string city, string postalCode, string adress, string number)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = cpf;
            Cellphone = cellphone;
            //Birthdate = birthdate;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Adress = adress;
            Number = number;
        }


        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        //public DateOnly Birthdate { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }

        
    }
}
