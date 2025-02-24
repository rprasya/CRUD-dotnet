using Microsoft.EntityFrameworkCore;
using RESTfulAPI.Model;

namespace RESTfulAPI.Data
{
    public class TutorialDbContext : DbContext
    {
        public TutorialDbContext(DbContextOptions<TutorialDbContext> options) : base(options) { }
        
        public virtual DbSet<Product> Products { get; set; }
    }
}
