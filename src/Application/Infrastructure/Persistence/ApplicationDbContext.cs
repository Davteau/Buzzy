using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<OfferingCategory> OfferingCategories { get; set; }
        public DbSet<EmploymentOffering> EmploymentOfferings { get; set; }
        public DbSet<InvitationLink> InvitationLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>();
        }
    }
}
