using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("employeetask")]
    public class EmployeeTask
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("employeeid")]
        public int EmployeeId { get; set; }

        [Column("taskid")]
        public int TaskId { get; set; }

        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Column("enddate")]
        public DateTime? EndDate { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("TaskId")]
        public ProjectTask ProjectTask { get; set; }
    }
}