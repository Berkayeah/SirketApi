using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("employee")]
    public class Employee : CoreEntity
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("surname")]
        public string Surname { get; set; } = string.Empty;

        [Column("unitid")]
        public int UnitId { get; set; }

        [Column("cityid")]
        public int CityId { get; set; }

        [Column("tcno")]
        public string Tcno { get; set; } = string.Empty;


        [ForeignKey("unitid")]
        public Unit? Unit { get; set; }

        [ForeignKey("cityid")]
        public City? City { get; set; }
    }

}

