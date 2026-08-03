using Microsoft.EntityFrameworkCore;
using Company.Domain.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Company.Infrastructure
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

    }
}