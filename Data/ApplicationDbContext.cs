using System.Text.Json;
using Login.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().HasQueryFilter(s => !s.IsDeleted);

            // UserToken has multiple primary keys.
            modelBuilder.Entity<UserToken>().HasKey(k => new { k.UserId, k.UserRefreshToken });
            modelBuilder
                .Entity<IdentityRole>()
                .HasData(
                    new IdentityRole()
                    {
                        Id = "0d8b99e9-8905-4e04-a1af-80d82dbebec2",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole()
                    {
                        Id = "198ee89a-e0df-4f24-b770-200fa6fa03d0",
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    },
                    new IdentityRole()
                    {
                        Id = "84d18e55-fcc0-4419-b308-8b84f293ee66",
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new IdentityRole()
                    {
                        Id = "fddd68cd-3c46-4657-b910-c97a14c95a28",
                        Name = "Client",
                        NormalizedName = "CLIENT"
                    }
                );
            // Set the role of super admin to admin.
            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = "5f1e8d3d-329e-474a-9526-1682fe508898",
                        RoleId = "0d8b99e9-8905-4e04-a1af-80d82dbebec2"
                    }
                );
        }

        public override int SaveChanges()
        {
            ConvertToSoftDelete();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            ConvertToSoftDelete();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ConvertToSoftDelete()
        {
            var deletedEntries = ChangeTracker
                .Entries<ISoftDeletable>()
                .Where(entry => entry.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in deletedEntries)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
            }
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<UserToken> UserRefreshTokens { get; set; }
    }
}
