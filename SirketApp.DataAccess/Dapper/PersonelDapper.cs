using System.Linq;
using Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using SirketApp.Core.Models;
using System.Collections.Generic;

namespace SirketApp.DataAccess.Dapper
{
	public class PersonelDapper
	{
		private readonly SirketDbContext _context;
		public PersonelDapper(SirketDbContext context)
		{
			_context = context;
		}

		public List<Personel> GetPersonellerDapper()
		{
			string connString = _context.Database.GetDbConnection().ConnectionString;

            string sql = @"
                SELECT 
                    p.*, 
                    b.*, 
                    s.* 
                FROM personel p
                INNER JOIN birim b ON p.birimid = b.birimid
                INNER JOIN sehir s ON p.sehirkodu = s.sehirkodu";

			using var connection = new NpgsqlConnection(connString);
			var personeller = connection.Query<Personel, Birim, Sehir, Personel>(sql,
				map: (personel, birim, sehir) =>
				{
					personel.Birim = birim;
					personel.Sehir = sehir;
					return personel;
				},
				splitOn: "birimid,sehirkodu").ToList();
			return personeller;
        }
	}
}

