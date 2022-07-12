using Domain.Models;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Ignore(x => x.EmailConfirmation);
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }


    }
}
