using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrareProMe.Domain;

namespace OrareProMe.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Rosary> Rosaries { get; set; }
        DbSet<Intention> Intentions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Prayer> Prayers { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }
}