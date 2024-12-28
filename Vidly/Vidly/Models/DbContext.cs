using System.Data.Entity;

namespace Vidly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection") // Ensure this matches the name of your connection string
        {
        }

        // Define DbSets for your models
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }

}