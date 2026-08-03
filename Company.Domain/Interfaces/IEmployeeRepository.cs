using System;
using Company.Domain.Models;
using System.Collections.Generic;

namespace Company.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        List<Employee> GetAllWithDetails();
        List<Employee> GetWithCity();
    }
}
