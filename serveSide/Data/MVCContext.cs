using Microsoft.EntityFrameworkCore;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Rank>? Rank { get; set; }


    }
}
