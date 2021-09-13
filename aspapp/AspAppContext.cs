using System.Data.Entity;
using aspapp.Models;

namespace aspapp
{
    public class AspAppContext : DbContext
    {
        public DbSet<Customer> Courses { get; set; }
        public DbSet<Movie> Authors { get; set; }
    }
}