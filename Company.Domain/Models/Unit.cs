using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("Unit")]
    public class Unit : CoreEntity
    {
        [Column("Unitname")]
        public string UnitName { get; set; } = string.Empty;
    }
}

