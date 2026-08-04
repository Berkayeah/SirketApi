using System;

namespace Company.Application.DtoRequests
{
    public class DtoEmployeeTaskRequest
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}