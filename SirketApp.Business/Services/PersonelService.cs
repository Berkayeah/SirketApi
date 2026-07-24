using SirketApp.DataAccess;
using SirketApp.Business.DTOs.DtoRequests;
using SirketApp.Business.DTOs.DtoResponses;
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
        public List<DtoPersonelResponse> GetPersoneller()
        {
            return _context.Personeller
                .Include(p => p.Birim)
                .Include(p => p.Sehir)
                .Select(p => new DtoPersonelResponse
                {
                    Ad = p.Ad,
                    Soyad = p.Soyad,
                    BirimAdi = p.Birim.BirimAdi,
                    SehirAdi = p.Sehir.SehirAdi
                })
                .ToList();
        }
        public List<DtoPersonelResponse> GetPersonellerDapper()
        {
            List<Personel> personeller = _personelDapper.GetPersonellerDapper();
            return personeller.Select(p => new DtoPersonelResponse
            {
                Ad = p.Ad,
                Soyad = p.Soyad,
                BirimAdi = p.Birim.BirimAdi,
                SehirAdi = p.Sehir.SehirAdi

            }).ToList();
        }

        public DtoResponse PersonelEkle(DtoPersonelRequest request)
        {
            var response = new DtoResponse();
            
            try
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

                response.ReqCode = 200;
                response.ReqMessage = "Personel başarıyla eklendi.";
            }

            catch (Exception ex)
            {
                response.ReqCode = 500;
                response.ReqMessage = "Personel eklenirken veritabanında bir hata oluştu!";
                response.ErrCode = "DB_INSERT_ERR";
                response.ErrMessage = ex.InnerException != null ?
                    ex.InnerException.Message : ex.Message;
            }
            return response;
        }

        public DtoResponse GetPersonelById(int id)
        {
            var response = new DtoResponse();
            try
            {
                var personel = _context.Personeller
                .Include(p => p.Birim)
                .Include(p => p.Sehir)
                .FirstOrDefault(p => p.Id == id);

                if (personel == null)
                {
                    response.ReqCode = 404;
                    response.ReqMessage = "Aranan personel bulunamadı.";
                    response.ErrCode = "NOT_FOUND";
                    return response;
                }
                response.Data = new DtoPersonelResponse
                {
                    Ad = personel.Ad,
                    Soyad = personel.Soyad,
                    BirimAdi = personel.Birim.BirimAdi,
                    SehirAdi = personel.Sehir.SehirAdi
                };
                response.ReqMessage = "Personel başarıyla getirildi.";
            }
            catch (Exception ex)
            {
                response.ReqCode = 500;
                response.ReqMessage = "Personel getirilirken sunucuda hata oluştu!";
                response.ErrCode = "DB_READ_ERR";
                response.ErrMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            
            }
            return response;
        }

        public DtoResponse PersonelGuncelle(int id, DtoPersonelRequest request)
        {
            var response = new DtoResponse();
            try
            {
                var personel = _context.Personeller.Find(id);
                if (personel == null)
                {
                    response.ReqCode = 404;
                    response.ReqMessage = "Güncellenecek personel bulunamadı.";
                    response.ErrCode = "NOT_FOUND";
                    return response;
                }
                personel.Ad = request.Ad;
                personel.Soyad = request.Soyad;
                personel.Tcno = request.Tcno;
                personel.BirimId = request.BirimId;
                personel.SehirKodu = request.SehirKodu;

                _context.SaveChanges();
                response.ReqMessage = "Personel başarıyla güncellendi.";
            }
            catch(Exception ex)
            {
                response.ReqCode = 500;
                response.ReqMessage = "Personel güncellenirken hata oluştu!";
                response.ErrCode = "DB_UPDATE_ERR";
                response.ErrMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            
            }
            return response;
        }

        public DtoResponse PersonelSil(int id)
        {
            var response = new DtoResponse();
            try
            {
                var personel = _context.Personeller.Find(id);
                if (personel == null)
                {
                    response.ReqCode = 404;
                    response.ReqMessage = "Silinecek personel bulunamadı.";
                    response.ErrCode = "NOT_FOUND";
                    return response;
                }
                _context.Personeller.Remove(personel);
                _context.SaveChanges();
                response.ReqMessage = "Personel başarıyla silindi.";
            }
            catch(Exception ex)
            {
                response.ReqCode = 500;
                response.ReqMessage = "Personel silinirken hata oluştu!";
                response.ErrCode = "DB_DELETE_ERR";
                response.ErrMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            
            }
            return response;
        }
    }
}

