using System;
using SirketApp.Core.Models;
using SirketApp.DataAccess.Repository.Abstracts;
using System.Collections.Generic;
using SirketApp.Business.Interfaces;

namespace SirketApp.Business.Services
{
	public class CityService : ICityService
	{
		private readonly ICityRepository _cityRepository;
		private readonly ICacheService _cacheService;


		public CityService(ICityRepository cityRepository, ICacheService cacheService)
		{
			_cityRepository = cityRepository;
			_cacheService = cacheService;
		}

		public List<Sehir> GetCities()
		{
			if (_cacheService.IsAdd("sehir_listesi"))
			{
				return _cacheService.Get<List<Sehir>>("sehir_listesi")!;
			}

			var cities = _cityRepository.GetAll();
			_cacheService.Add("sehir_listesi", cities, 60);

			return cities;
		}
	}
}

