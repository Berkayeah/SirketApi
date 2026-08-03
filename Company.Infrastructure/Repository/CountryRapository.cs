using System;
using Company.Domain.Models;
using Company.Domain.Interfaces;

namespace Company.Infrastructure.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(CompanyDbContext context) : base(context)
        {
        }
    }
}

