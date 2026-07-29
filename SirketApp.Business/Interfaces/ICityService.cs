using System;
using SirketApp.Core.Models;
using System.Collections.Generic;

namespace SirketApp.Business.Interfaces
{
	public interface ICityService
	{
		List<Sehir> GetCities();
	}
}

