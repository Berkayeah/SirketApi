using System.Collections.Generic;
using Company.Domain.Models;

namespace Company.Domain.Interfaces
{
    public interface IEmployeeDapper
    {
        List<Employee> GetEmployeesDapper();
    }
}