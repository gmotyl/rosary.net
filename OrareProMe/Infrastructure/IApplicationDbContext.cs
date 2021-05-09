using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrareProMe.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Rosary> Rosaries { get; set; }
        DbSet<Domain.Intention> Intentions { get; set; }
        DbSet<Domain.User> Users { get; set; }
        DbSet<Domain.Prayer> Prayers { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }
}