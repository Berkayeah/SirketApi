using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirektApi.Models
{
	[Table("sehir")]
	public class Sehir
	{
		[Key]
		[Column("sehirkodu")]
		public string SehirKodu { get; set; }

        [Column("sehiradi")]
        public string SehirAdi { get; set; }
    }
}

