using System;
using Company.Domain.Models;
using Company.Domain.Interfaces;

namespace Company.Infrastructure.Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}

