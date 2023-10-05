using HistorySpot.Models;
using Microsoft.EntityFrameworkCore;

namespace HistorySpot.Data
{
    public class HistorySpotDbContext : DbContext
    {
        public HistorySpotDbContext(DbContextOptions<HistorySpotDbContext> options) : base(options) { }
        public DbSet<Badge> badges { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<HistoricalPoint> historicalPoints { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<TopHistoricalSite> topHistoricalSites { get; set; }
    }
}
