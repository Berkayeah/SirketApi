using System;
using Company.Domain.Models;
using System.Collections.Generic;
using Company.Application.Interfaces;
using Company.Domain.Constants;
using System.Linq;
using Company.Domain.Interfaces;


namespace Company.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ICacheService _cacheService;

        public UnitService(IUnitRepository unitRepository, ICacheService cacheService)
        {
            _unitRepository = unitRepository;
            _cacheService = cacheService;
        }

        public List<Unit> GetUnits()
        {
            if (_cacheService.IsAdd(GeneralConstants.UnitCacheKey))
            {
                return _cacheService.Get<List<Unit>>(GeneralConstants.UnitCacheKey!);
            }

            var units = _unitRepository.GetAll();
            _cacheService.Add(GeneralConstants.UnitCacheKey, units, 60);
            return units;
        }

        public Unit GetUnitById(int id)
        {
            var units = GetUnits();
            return units.FirstOrDefault(x => x.Id == id);
        }

        public void AddUnit(Unit unit)
        {
            _unitRepository.Add(unit);
            _unitRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.UnitCacheKey);
        }

        public void UpdateUnit(Unit unit)
        {
            _unitRepository.Update(unit);
            _unitRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.UnitCacheKey);
        }
        public void DeleteUnit(int id)
        {
            var deletedUnit = _unitRepository.GetById(id);
            if (deletedUnit != null)
            {
                _unitRepository.Delete(deletedUnit);
                _unitRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.UnitCacheKey);
            }
        }
    }
}

