using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PDP104.Models;
using System.Reflection.Emit;

namespace PDP104.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed(); // thêm dữ liệu mẫu

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

            builder.Entity<IdentityRole>().ToTable("AspNetRoles");
            builder.Entity<IdentityUser>().ToTable("AspNetUsers");

            builder.Entity<IdentityRoleClaim<string>>()
                    .HasOne<IdentityRole>()
                    .WithMany()
                    .HasForeignKey(rc => rc.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IdentityUserClaim<string>>()
                    .HasOne<IdentityUser>()
                    .WithMany()
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<IdentityUserLogin<string>>()
                    .HasOne<IdentityUser>()
                    .WithMany()
                    .HasForeignKey(ul => ul.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IdentityUserToken<string>>()
                    .HasOne<IdentityUser>()
                    .WithMany()
                    .HasForeignKey(ut => ut.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IdentityUserRole<string>>()
                    .HasOne<IdentityUser>()
                    .WithMany()
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IdentityUserRole<string>>()
                    .HasOne<IdentityRole>()
                    .WithMany()
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<StorageOrderImages> StorageOrderImages { get; set; }

        public DbSet<StorageOrderServices> StorageOrderServices { get; set; }

        public DbSet<StorageOrders> StorageOrders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<StorageSpaces> StorageSpaces { get; set; }
        public DbSet<WareHouses> WareHouses { get; set; }

    }
}
