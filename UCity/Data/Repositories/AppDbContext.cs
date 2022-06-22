using Microsoft.EntityFrameworkCore;
using UCity.Data.Models;
using UCity.Data.Models.ServiceModels;

namespace UCity.Data.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventPart> EventParts { get; set; }
    }
}