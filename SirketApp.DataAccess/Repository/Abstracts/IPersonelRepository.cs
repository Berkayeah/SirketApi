using System;
using SirketApp.Core.Models;
using System.Collections.Generic;

namespace SirketApp.DataAccess.Repository.Abstracts
{
	public interface IPersonelRepository : IRepositoryBase<Personel>
	{
		List<Personel> GetAllWithDetails();
		List<Personel> GetWithCity();
	}
}
