using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirketApp.Core.Models
{
    [Table("personel")]
    public class Personel : CoreEntity
    {
        [Column("ad")]
        public string Ad { get; set; } = string.Empty;

        [Column("soyad")]
        public string Soyad { get; set; } = string.Empty;

        [Column("birimid")]
        public int BirimId { get; set; }

        [Column("sehirid")]
        public int SehirId { get; set; }

        [Column("tcno")]
        public string Tcno { get; set; } = string.Empty;


        [ForeignKey("BirimId")]
        public Birim? Birim { get; set; }

        public Sehir? Sehir { get; set; }
    }

}

