using System;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SirektApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SirektApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class PersonelController : ControllerBase
	{
		private readonly SirketDbContext _context;
		public PersonelController(SirketDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetPersoneller()
		{
			var personeller = _context.Personeller
				.Include(p => p.Birim)
				.Include(p => p.Sehir)
				.Select(p => new PersonelDetayDto
				{
					Ad = p.Ad,
					Soyad = p.Soyad,
					BirimAdi = p.Birim.BirimAdi,
					SehirAdi = p.Sehir.SehirAdi
				})
				.ToList();

			return Ok(personeller);
		}
	}

	public class PersonelDetayDto
	{
			public string Ad { get; set; }
			public string Soyad { get; set; }
			public string BirimAdi { get; set; }
			public string SehirAdi { get; set; }
	}
	
}
