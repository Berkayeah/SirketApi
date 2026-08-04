using System;
using Company.Domain.Models;
using System.Collections.Generic;
using Company.Application.Interfaces;
using Company.Domain.Constants;
using System.Linq;
using Company.Domain.Interfaces;

namespace Company.Application.Services
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

        public List<City> GetCities()
        {
            if (_cacheService.IsAdd(GeneralConstants.CityCacheKey))
            {
                return _cacheService.Get<List<City>>(GeneralConstants.CityCacheKey!);
            }

            var cities = _cityRepository.GetAll();
            _cacheService.Add(GeneralConstants.CityCacheKey, cities, 60);

            return cities;

        }


        public City GetCityById(int id)
        {
            //return _cityRepository.GetById(id);

            var cities = GetCities();
            return cities.FirstOrDefault(x => x.Id == id);
        }

        public void AddCity(City city)
        {
            _cityRepository.Add(city);
            _cityRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.CityCacheKey);

            //var cities = GetCities() ?? new List<City>();
            //city.Id = cities.Any() ? cities.Max(c => c.Id) + 1 : 1;
            //cities.Add(city);
            // _cacheService.Remove(GeneralConstants.CityCacheKey);
        }

        public void UpdateCity(City city)
        {
            _cityRepository.Update(city);
            _cityRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.CityCacheKey);

            //var cities = GetCities();
            //var existingCity = cities.FirstOrDefault(x => x.Id == city.Id);
            //if (existingCity != null)
            //{
            //	cities.Remove(existingCity);
            //	cities.Add(city);
            //             _cacheService.Remove(GeneralConstants.CityCacheKey);

            //         }
        }

        public void DeleteCity(int id)
        {
            var deletedCity = _cityRepository.GetById(id);
            if (deletedCity != null)
            {
                _cityRepository.Delete(deletedCity);
                _cityRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.CityCacheKey);
            }

            //var cities = GetCities();
            //         var cityToDelete = cities.FirstOrDefault(x => x.Id == id);

            //         if (cityToDelete != null)
            //         {
            //             cities.Remove(cityToDelete);
            //             _cacheService.Remove(GeneralConstants.CityCacheKey); 
            //         }
        }
    }
}

