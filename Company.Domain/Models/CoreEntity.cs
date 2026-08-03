using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    public class CoreEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        public int Status { get; set; } = 1;
    }
}
