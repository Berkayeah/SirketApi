using System;
using System.Collections.Generic;
using Company.Domain.Models;
namespace Company.Application.Interfaces
{
    public interface IUnitService
    {
        List<Unit> GetUnits();
        Unit GetUnitById(int id);
        void AddUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int id);
    }
}