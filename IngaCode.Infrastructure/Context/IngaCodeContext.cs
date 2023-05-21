using Microsoft.EntityFrameworkCore;
using IngaCode.Domain.Entities;
using System.Reflection;

namespace IngaCode.Infrastructure.Context
{
    public class IngaCodeContext : DbContext
    {
        public IngaCodeContext(DbContextOptions<IngaCodeContext> options) : base(options)
        {

        }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Collaborators> Collaborator { get; set; }
        public virtual DbSet<TimeTrackers> TimeTracker { get; set; }
        public virtual DbSet<Tasks> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Users
            modelBuilder.Entity<Users>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateAt = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).UpdateAt = DateTime.Now;
                }
                else
                {
                    ((BaseEntity)entityEntry.Entity).DeleteAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync();
        }
    }
}
