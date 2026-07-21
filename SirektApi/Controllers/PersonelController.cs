using System;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SirektApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class PersonelController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetPersoneller()
		{
			string connString = "Host=localhost;Database=PersonelOrnegi;Username=postgres;Password=0017";
			var personelListesi = new List<PersonelDetayDto>();
			try
			{
				using var connection = new NpgsqlConnection(connString);
				connection.Open();

				string sql = @"
					SELECT p.ad, p.soyad, b.birimadi, s.sehiradi 
                    FROM personel p
                    INNER JOIN birim b ON p.birimid = b.birimid
                    INNER JOIN sehir s ON p.sehirkodu = s.sehirkodu";
				using var command = new NpgsqlCommand(sql, connection);
				using var reader = command.ExecuteReader();
				while (reader.Read())
				{
					personelListesi.Add(new PersonelDetayDto
					{
						Ad = reader.GetString(0),
						Soyad = reader.GetString(1),
						BirimAdi = reader.GetString(2),
						SehirAdi = reader.GetString(3)
					});
				}
				return Ok(personelListesi);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
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

