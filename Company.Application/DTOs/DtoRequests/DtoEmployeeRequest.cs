using System;
using Company.Application.DTOs.DtoResponses;

namespace Company.Application.DTOs.DtoRequests
{
    public class DtoEmployeeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public int CityId { get; set; }
        public string Tcno { get; set; } = string.Empty;
    }
}

