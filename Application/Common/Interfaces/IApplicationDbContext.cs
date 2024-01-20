using PCBuilder.Domain.Entities;


namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<PCComponent> PCComponent { get; }

        public DbSet<PCComponentTag> PCComponentTag { get; }

        public DbSet<PriceComponent> PriceComponents { get; }

        public DbSet<Tag> Tag { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
