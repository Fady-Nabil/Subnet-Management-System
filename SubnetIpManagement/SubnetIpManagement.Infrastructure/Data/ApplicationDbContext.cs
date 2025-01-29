using Microsoft.EntityFrameworkCore;
using SubnetIpManagement.Domain.Entities;

namespace SubnetIpManagement.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Subnet> Subnets { get; set; }
        public required DbSet<IpAddress> IpAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IpAddress>()
                .HasOne<Subnet>()
                .WithMany(s => s.IPAddresses)
                .HasForeignKey(ip => ip.SubnetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasMany(u => u.Subnets)
                      .WithOne(s => s.User)
                      .HasForeignKey(s => s.CreatedUserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.IPAddresses)
                      .WithOne(ip => ip.User)
                      .HasForeignKey(ip => ip.CreatedUserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Subnet>(entity =>
            {
                entity.HasKey(s => s.SubnetId);
                entity.HasMany(s => s.IPAddresses)
                      .WithOne(ip => ip.Subnet)
                      .HasForeignKey(ip => ip.SubnetId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IpAddress>(entity =>
            {
                entity.HasKey(ip => ip.IpId);
            });
        }

    }
}
