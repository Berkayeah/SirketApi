using System;
using Company.Domain.Models;
using System.Collections.Generic;
using Company.Application.Interfaces;
using Company.Domain.Constants;
using System.Linq;
using Company.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace Company.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICacheService _cacheService;

        public CountryService(ICountryRepository countryRepository, ICacheService cacheService)
        {
            _countryRepository = countryRepository;
            _cacheService = cacheService;
        }

        public List<Country> GetCountries()
        {
            if (_cacheService.IsAdd(GeneralConstants.CountryCacheKey))
            {
                return _cacheService.Get<List<Country>>(GeneralConstants.CountryCacheKey!);
            }

            var countries = _countryRepository.GetAll();
            _cacheService.Add(GeneralConstants.CountryCacheKey, countries, 60);
            return countries;
        }

        public Country GetCountryById(int id)
        {
            var countries = GetCountries();
            return countries.FirstOrDefault(x => x.Id == id);
        }

        public void AddCountry(Country country)
        {
            _countryRepository.Add(country);
            _countryRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.CountryCacheKey);
        }

        public void UpdateCountry(Country country)
        {
            _countryRepository.Update(country);
            _countryRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.CountryCacheKey);
        }
        public void DeleteCountry(int id)
        {
            var deletedCountry = _countryRepository.GetById(id);
            if (deletedCountry != null)
            {
                _countryRepository.Delete(deletedCountry);
                _countryRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.CountryCacheKey);
            }
        }
    }
}

