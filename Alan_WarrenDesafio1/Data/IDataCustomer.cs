using Alan_WarrenDesafio1.Models;

namespace Alan_WarrenDesafio1.Data
{
    public interface IDataCustomer
    {
        public List<Customer> Customers { get; set; }

        public void Add(Customer customer);
        public void Update(Customer ctm, Customer customer);
        public bool Delete(int id);
        public bool VerifyEmail(Customer customer);
    }
}
