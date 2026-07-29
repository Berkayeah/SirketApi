using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirketApp.Core.Models
{
    [Table("birim")]
	public class Birim : CoreEntity
	{
        [Column("birimadi")]
        public string BirimAdi { get; set; } = string.Empty;
    }
}

