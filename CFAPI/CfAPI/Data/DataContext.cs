using CfAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CfAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<TitreFoncier> Titres { get; set; }
        public DbSet<CF> CFs { get; set; }

    }
}
