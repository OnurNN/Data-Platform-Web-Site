using Microsoft.EntityFrameworkCore;
using Proje.Models.DBEntities;

namespace Proje.DataAccessLayer
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) 
        { 
        }

        public DbSet<Company>Companies { get; set; }
       
        

    }
}
