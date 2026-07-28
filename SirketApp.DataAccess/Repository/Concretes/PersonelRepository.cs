using System;
using Microsoft.EntityFrameworkCore;
using SirketApp.Core.Models;
using SirketApp.DataAccess.Repository.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace SirketApp.DataAccess.Repository.Concretes
{
	public class PersonelRepository : RepositoryBase<Personel>, IPersonelRepository
	{
		public PersonelRepository(SirketDbContext context) : base(context)
		{
		}

		public List<Personel> GetAllWithDetails()
		{
			return _context.Personeller
				.Include(p => p.Birim)
				.Include(p => p.Sehir)
				.ToList();
		}
	}
}

