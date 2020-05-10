using Microsoft.EntityFrameworkCore;

// Bind Models to DB tables
namespace asprazor.Model {

    public class ApplicationDbContext: DbContext {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Book> Book { get; set; }
    }
}