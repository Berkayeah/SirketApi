using Company.Domain.Interfaces;
using Company.Domain.Models;

namespace Company.Infrastructure.Repository
{
    public class ProjectTaskRepository : RepositoryBase<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}