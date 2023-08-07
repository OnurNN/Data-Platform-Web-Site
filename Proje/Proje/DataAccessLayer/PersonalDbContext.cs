using Microsoft.EntityFrameworkCore;
using Proje.Models.DBEntities;

namespace Proje.DataAccessLayer
{
    public class PersonalDbContext : DbContext
    {
        public PersonalDbContext(DbContextOptions<PersonalDbContext> options) : base(options)
        {
        }

        public DbSet<Personal> Personals { get; set; }



    }
}
