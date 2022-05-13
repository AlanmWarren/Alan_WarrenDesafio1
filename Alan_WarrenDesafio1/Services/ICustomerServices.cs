using Alan_WarrenDesafio1.Models;

namespace Alan_WarrenDesafio1.Data
{
    public interface ICustomerServices
    {
        IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null);
        public Customer GetById(Func<Customer, bool> predicate);
        public Customer GetByFullName(string fullName);
        public Customer GetByEmail(string email);
        public Customer GetByCpf(string cpf);
        public bool Create(Customer newCustomer);
        public int Update(int id, Customer newCustomer);
        public bool Delete(int id);
    }
}
