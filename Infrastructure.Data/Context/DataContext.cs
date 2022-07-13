using Domain.Models;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblie = Assembly.Load("Infrastructure.Data");
            modelBuilder.ApplyConfigurationsFromAssembly(assemblie);
        }
    }
}
