using System.Collections.Generic;
using Company.Application.DtoRequests;
using Company.Domain.Models;

namespace Company.Application.Services
{
    public interface IEmployeeTaskService
    {
        List<EmployeeTask> GetAll();
        EmployeeTask GetById(int id);
        void Add(DtoEmployeeTaskRequest request);
        void Update(int id, DtoEmployeeTaskRequest request);
        void Delete(int id);
    }
}