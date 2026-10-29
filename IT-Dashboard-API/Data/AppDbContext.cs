using IT_Dashboard_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Dashboard_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<IT_Dashboard_API.Models.HardwareModel> HardwareModel { get; set; } = default!;
        public DbSet<IT_Dashboard_API.Models.TicketModel> TicketModel { get; set; } = default!;
        public DbSet<IT_Dashboard_API.Models.UserModel> UserModel { get; set; } = default!;
        public DbSet<IT_Dashboard_API.Models.TicketNoteModel> TicketNoteModel { get; set; } = default!;

        // Override SaveChangesAsync to automatically set CreatedAt and UpdatedAt timestamps
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
