using Microsoft.EntityFrameworkCore;
namespace proyecto100dias.Models
{
    public class pieroDbContext : DbContext
    {
        public pieroDbContext(DbContextOptions<pieroDbContext> options)
            : base(options)
        {
        }

        public DbSet<trabajadores> trabajadores { get; set; } = null!;
    }
}
