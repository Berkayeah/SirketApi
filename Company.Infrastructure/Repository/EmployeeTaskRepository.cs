using Company.Domain.Interfaces;
using Company.Domain.Models;

namespace Company.Infrastructure.Repository
{
    public class EmployeeTaskRepository : RepositoryBase<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}