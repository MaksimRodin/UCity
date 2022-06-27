using Microsoft.EntityFrameworkCore;
using UCity.Data.Models;
using UCity.Data.Models.Auth;

namespace UCity.Data.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventPart> EventParts { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}