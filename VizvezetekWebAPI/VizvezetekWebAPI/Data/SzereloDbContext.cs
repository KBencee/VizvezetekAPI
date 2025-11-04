using Microsoft.EntityFrameworkCore;
using VizvezetekWebAPI.Models;

namespace VizvezetekWebAPI.Data
{
    public class SzereloDbContext : DbContext
    {
        public SzereloDbContext(DbContextOptions<SzereloDbContext> options) : base(options)
        {
        }
        public DbSet<Szerelo> Szerelok { get; set; }
        public DbSet<Hely> Helyek { get; set; }
        public DbSet<Munkalap> Munkalapok { get; set; }
    }
}
