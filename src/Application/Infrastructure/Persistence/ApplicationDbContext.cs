using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
