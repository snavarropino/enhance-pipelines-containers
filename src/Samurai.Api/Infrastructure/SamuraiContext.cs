using Microsoft.EntityFrameworkCore;

namespace Samurai.Api.Infrastructure
{
    public class SamuraiContext: DbContext
    {
        public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Samurai> Samurais { get; set; }
    }
}
