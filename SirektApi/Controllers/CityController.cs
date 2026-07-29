using System;
using Microsoft.AspNetCore.Mvc;
using SirketApp.Business.Interfaces;

namespace SirketApi.Controllers
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
	}
}

