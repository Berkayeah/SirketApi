using System;
using Company.Domain.Models;
using Company.Domain.Interfaces;

namespace Company.Infrastructure.Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}

