using System;
using Microsoft.AspNetCore.Mvc;
using Company.Application.Interfaces;
using Company.Domain.Models;
using System.Diagnostics.Metrics;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryService.GetCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound("Ülke bulunamadı.");
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] Country country)
        {
            _countryService.AddCountry(country);
            return Ok("Ülke eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            _countryService.UpdateCountry(country);
            return Ok("Ülke güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _countryService.DeleteCountry(id);
            return Ok("Ülke silindi.");
        }
    }
}

