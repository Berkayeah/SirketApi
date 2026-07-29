using System;
using SirketApp.Core.Models;
using SirketApp.DataAccess.Repository.Abstracts;

namespace SirketApp.DataAccess.Repository.Concretes
{
	public class CityRepository : RepositoryBase<Sehir>, ICityRepository
	{
		public CityRepository(SirketDbContext context) : base(context)
		{
		}
	}
}

