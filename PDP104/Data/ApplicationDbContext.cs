using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PDP104.Models;

namespace PDP104.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inventory>()
                .HasOne(i => i.StorageOrders)
                .WithOne(s => s.Inventory)
                .HasForeignKey<StorageOrders>(s => s.InventoryId);
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins")
                       .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles")
                        .HasKey(r => new { r.UserId, r.RoleId });

            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens")
                        .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims");

            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims");
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<StorageOrders> StorageOrders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<StorageSpaces> StorageSpaces { get; set; }
        public DbSet<WareHouses> WareHouses { get; set; }

    }
}
