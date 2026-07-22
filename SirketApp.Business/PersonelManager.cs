using System;
using Npgsql;
using SirketApp.DataAccess;
using SirketApp.Business.DTOs;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace SirketApp.Business
{
    public class PersonelManager : IPersonelService
    {
        private readonly SirketDbContext _context;

        public PersonelManager(SirketDbContext context)
        {
            _context = context;
        }
        public List<PersonelDetayDto> GetPersoneller()
        {
            return _context.Personeller
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
        }
        public List<PersonelDetayDto> GetPersonellerDapper()
        {
            string connString = _context.Database.GetDbConnection().ConnectionString;
            string sql = @"
                SELECT 
                    p.ad AS Ad, 
                    p.soyad AS Soyad, 
                    b.birimadi AS BirimAdi, 
                    s.sehiradi AS SehirAdi 
                FROM personel p
                INNER JOIN birim b ON p.birimid = b.birimid
                INNER JOIN sehir s ON p.sehirkodu = s.sehirkodu";

            using var connection = new NpgsqlConnection(connString);
            return connection.Query<PersonelDetayDto>(sql).ToList();
        }
    }
}

