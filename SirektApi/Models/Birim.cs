using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirektApi.Models
{
	[Table("birim")]
	public class Birim
	{
		[Key]
		[Column("birimid")]
		public int BirimId { get; set; }

        [Column("birimadi")]
        public string BirimAdi { get; set; }
    }
}

