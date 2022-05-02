using Alan_WarrenDesafio1.Models;

namespace Alan_WarrenDesafio1.Data
{
    public interface IDataCustomer
    {
        public List<Customer> Customers { get; set; }

        public void Create(Customer customerInput);
        public void Update(Customer customer, Customer customerInput);
        public void Delete(Customer customer);
    }
}
