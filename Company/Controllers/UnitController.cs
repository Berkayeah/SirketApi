using System;
using Microsoft.AspNetCore.Mvc;
using Company.Application.Interfaces;
using Company.Domain.Models;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public IActionResult GetUnits()
        {
            var units = _unitService.GetUnits();
            return Ok(units);
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitById(int id)
        {
            var unit = _unitService.GetUnitById(id);
            if (unit == null)
            {
                return NotFound("Unit bulunamadı.");
            }
            return Ok(unit);
        }

        [HttpPost]
        public IActionResult AddUnits([FromBody] Unit unit)
        {
            _unitService.AddUnit(unit);
            return Ok("Unit eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateUnit([FromBody] Unit unit)
        {
            _unitService.UpdateUnit(unit);
            return Ok("Unit güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            _unitService.DeleteUnit(id);
            return Ok("Unit silindi.");
        }
    }
}

