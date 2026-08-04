using System;
using Company.Domain.Models;
using System.Collections.Generic;

namespace Company.Application.Interfaces
{
    public interface ICityService
    {
        List<City> GetCities();
        City GetCityById(int id);
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int id);
    }
}

