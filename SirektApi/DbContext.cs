using Microsoft.EntityFrameworkCore;
using SirektApi.Models;

namespace SirektApi
{
	public class SirketDbContext : DbContext
	{
		public SirketDbContext(DbContextOptions<SirketDbContext> options) : base(options)
		{

		}
		public DbSet<Personel> Personeller { get; set; }
		public DbSet<Birim> Birimler { get; set; }
		public DbSet<Sehir> Sehirler { get; set; }

	}
}

