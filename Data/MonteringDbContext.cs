using Microsoft.EntityFrameworkCore;
using MonteringService.Models;

namespace MonteringService.Data
{
    public class MonteringDbContext : DbContext
    {
        public MonteringDbContext(DbContextOptions<MonteringDbContext> options)
            : base(options)
        {
        }

        public DbSet<MonteringJob> MonteringJobs { get; set; } = null!;
    }
}
