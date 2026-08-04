using System;
using Company.Domain.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Company.Application.Interfaces
{
    public interface ICountryService
    {
        List<Country> GetCountries();
        Country GetCountryById(int id);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
    }
}

