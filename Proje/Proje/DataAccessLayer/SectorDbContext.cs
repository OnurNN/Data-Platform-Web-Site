using Microsoft.EntityFrameworkCore;
using Proje.Models.DBEntities;

namespace Proje.DataAccessLayer
{
    public class SectorDbContext : DbContext
    {
        public SectorDbContext(DbContextOptions<SectorDbContext> options) : base(options)
        {
        }
        public DbSet<Sector>Sectors { get; set; }

    }
}
