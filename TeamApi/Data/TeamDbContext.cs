using Microsoft.EntityFrameworkCore;
using TeamApi.Models;

namespace TeamApi.Data
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
