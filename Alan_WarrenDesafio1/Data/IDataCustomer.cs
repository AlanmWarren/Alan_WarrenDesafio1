using Alan_WarrenDesafio1.Models;

namespace Alan_WarrenDesafio1.Data
{
    public interface IDataCustomer
    {
        public List<Customer> Customers { get; set; }

        public void Add(Customer customer);
        public bool Update(int id, Customer customer);
        public bool Delete(int id);
         
    }
}
