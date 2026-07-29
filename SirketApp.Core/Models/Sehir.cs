using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirketApp.Core.Models
{
	[Table("sehir")]
	public class Sehir : CoreEntity
	{
		[Column("sehirkodu")]
		public string SehirKodu { get; set; } = string.Empty;

		[Column("sehiradi")]
		public string SehirAdi { get; set; } = string.Empty;
    }
}

