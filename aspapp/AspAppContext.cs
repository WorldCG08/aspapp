using System.Data.Entity;
using aspapp.Models;

namespace aspapp
{
    public class AspAppContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}