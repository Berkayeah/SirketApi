using System.Linq;
using Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Company.Domain.Models;
using Company.Domain.Interfaces;
using System.Collections.Generic;

namespace Company.Infrastructure.Dapper
{
    public class EmployeeDapper : IEmployeeDapper
    {
        private readonly CompanyDbContext _context;

        public EmployeeDapper(CompanyDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployeesDapper()
        {
            string connString = _context.Database.GetDbConnection().ConnectionString;

            string sql = @"
                SELECT 
                    p.*, 
                    b.*, 
                    s.* 
                FROM Employee p
                INNER JOIN Unit b ON p.Unitid = b.Unitid
                INNER JOIN City s ON p.Cityid = s.Cityid";
            using var connection = new NpgsqlConnection(connString);

            var employees = connection.Query<Employee, Unit, City, Employee>(sql,
                map: (employee, unit, city) =>
                {
                    employee.Unit = unit;
                    employee.City = city;
                    return employee;
                },
                splitOn: "Unitid,Cityid").ToList();

            return employees;
        }
    }
}