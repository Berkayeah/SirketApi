using Microsoft.EntityFrameworkCore;
using SirketApp.Core.Models; 

namespace SirketApp.DataAccess 
{
    public class SirketDbContext : DbContext
    {
        public SirketDbContext(DbContextOptions<SirketDbContext> options) : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; } = null!;
        public DbSet<Birim> Birimler { get; set; } = null!;
        public DbSet<Sehir> Sehirler { get; set; } = null!;
    }
}