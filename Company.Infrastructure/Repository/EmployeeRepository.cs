using System;
using Microsoft.EntityFrameworkCore;
using Company.Domain.Models;
using Company.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Company.Infrastructure.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }

        public List<Employee> GetAllWithDetails()
        {
            return _context.Employees
                .Include(p => p.Unit)
                .Include(p => p.City)
                .ToList();
        }

        public List<Employee> GetWithCity()
        {
            return _context.Employees
                .Include(p => p.City)
                .ToList();
        }
    }
}
