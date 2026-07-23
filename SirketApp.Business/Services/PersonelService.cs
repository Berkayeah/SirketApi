using SirketApp.DataAccess;
using SirketApp.Business.DTOs.RequestDtos;
using SirketApp.Business.DTOs.ResponseDtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SirketApp.Core.Models;
using SirketApp.DataAccess.Dapper;

namespace SirketApp.Business.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly SirketDbContext _context;
        private readonly PersonelDapper _personelDapper;

        public PersonelService(SirketDbContext context, PersonelDapper personelDapper)
        {
            _context = context;
            _personelDapper = personelDapper;
        }
        public List<PersonelResponseDto> GetPersoneller()
        {
            return _context.Personeller
                .Include(p => p.Birim)
                .Include(p => p.Sehir)
                .Select(p => new PersonelResponseDto
                {
                    Ad = p.Ad,
                    Soyad = p.Soyad,
                    BirimAdi = p.Birim.BirimAdi,
                    SehirAdi = p.Sehir.SehirAdi
                })
                .ToList();
        }
        public List<PersonelResponseDto> GetPersonellerDapper()
        {
            List<Personel> personeller = _personelDapper.GetPersonellerDapper();
            return personeller.Select(p => new PersonelResponseDto
            {
                Ad = p.Ad,
                Soyad = p.Soyad,
                BirimAdi = p.Birim.BirimAdi,
                SehirAdi = p.Sehir.SehirAdi

            }).ToList();
        }

        public void PersonelEkle(PersonelRequestDto request)
        {
            var yeniPersonel = new Personel
            {
                Ad = request.Ad,
                Soyad = request.Soyad,
                BirimId = request.BirimId,
                SehirKodu = request.SehirKodu,
                Tcno = request.Tcno
            };

            _context.Personeller.Add(yeniPersonel);
            _context.SaveChanges();
        }
    }
}

