using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirketApp.Core.Models
{
	[Table("sehir")]
	public class Sehir
	{
		[Key]
		[Column("sehirkodu")]
		public int SehirKodu { get; set; }

        [Column("sehiradi")]
        public string SehirAdi { get; set; }
    }
}

