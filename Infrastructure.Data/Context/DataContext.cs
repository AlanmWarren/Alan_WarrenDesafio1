using Domain.Models;
using EntityFrameworkCore.AutoHistory.Extensions;
using Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.EnsureAutoHistory(() => new CustomAutoHistory { CustomField = "CustomValue" });
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EnableAutoHistory<CustomAutoHistory>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
        }

        public override int SaveChanges()
        {
            var addedEntities = this.DetectChanges(EntityState.Added);

            this.EnsureAutoHistory();
            var affectedRows = base.SaveChanges();

            this.EnsureAutoHistory(addedEntities);
            affectedRows += base.SaveChanges();

            return affectedRows;
        }
    }
}
