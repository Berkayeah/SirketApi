using System;
using Microsoft.AspNetCore.Mvc;
using Company.Application.Interfaces;
using Company.Domain.Models;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            return Ok(_cityService.GetCityById(id));
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] City city)
        {
            _cityService.AddCity(city);
            return Ok("Şehir başarıyla eklendi ve cache temizlendi.");
        }

        [HttpPut]
        public IActionResult UpdateCity([FromBody] City city)
        {
            _cityService.UpdateCity(city);
            return Ok("Şehir başarıyla güncellendi ve cache temizlendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            _cityService.DeleteCity(id);
            return Ok("Şehir başarıyla silindi ve cache temizlendi.");
        }
    }
}
