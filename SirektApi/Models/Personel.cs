using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SirektApi.Models
{
    [Table("personel")]
    public class Personel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ad")]
        public string Ad { get; set; }

        [Column("soyad")]
        public string Soyad { get; set; }

        [Column("birimid")]
        public int BirimId { get; set; }

        [Column("sehirkodu")]
        public string SehirKodu { get; set; }


        [ForeignKey("BirimId")]
        public Birim Birim { get; set; }

        [ForeignKey("SehirKodu")]
        public Sehir Sehir { get; set; }
    }

}

