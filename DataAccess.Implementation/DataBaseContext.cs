using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }
    }
}
