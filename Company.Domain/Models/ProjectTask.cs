using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("task")]
    public class ProjectTask
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("effort")]
        public int Effort { get; set; }

        public ICollection<EmployeeTask> EmployeeTask { get; set; } = new List<EmployeeTask>();
    }
}