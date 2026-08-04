using Company.Application.DTOs.DtoRequests;
using Company.Application.DTOs.DtoResponses;
using System.Collections.Generic;

namespace Company.Application.Services
{
    public interface IEmployeeService
    {
        List<DtoEmployeeResponse> GetEmployees();
        List<DtoEmployeeResponse> GetEmployeesDapper();

        public DtoResponse EmployeeAdd(DtoEmployeeRequest request);

        public DtoResponse GetEmployeeById(int id);

        public DtoResponse EmployeeUpdate(int id, DtoEmployeeRequest request);

        DtoResponse EmployeeHardDelete(int id);
        DtoResponse EmployeeSoftDelete(int id);

        List<int> GetCityCodes();
    }
}
