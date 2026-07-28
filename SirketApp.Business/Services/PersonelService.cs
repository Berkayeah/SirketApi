using SirketApp.DataAccess;
using SirketApp.Business.DTOs.DtoRequests;
using SirketApp.Business.DTOs.DtoResponses;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SirketApp.Core.Models;
using SirketApp.DataAccess.Dapper;
using SirketApp.DataAccess.Repository.Abstracts;

namespace SirketApp.Business.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly PersonelDapper _personelDapper;

        public PersonelService(IPersonelRepository personelRepository, PersonelDapper personelDapper)
        {
            _personelRepository = personelRepository;
            _personelDapper = personelDapper;
        }

        public List<DtoPersonelResponse> GetPersoneller()
        {
            var personeller = _personelRepository.GetAllWithDetails();

            return personeller.Select(p => new DtoPersonelResponse
                {
                    Ad = p.Ad,
                    Soyad = p.Soyad,
                    BirimAdi = p.Birim != null ? p.Birim.BirimAdi : string.Empty,
                    SehirAdi = p.Sehir != null ? p.Sehir.SehirAdi : string.Empty
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
                BirimAdi = p.Birim?.BirimAdi ?? string.Empty,
                SehirAdi = p.Sehir?.SehirAdi ?? string.Empty
            }).ToList();
        }

        public DtoResponse PersonelAdd(DtoPersonelRequest request)
        {
            try
            {
                var yeniPersonel = new Personel
                {
                    Ad = request.Ad,
                    Soyad = request.Soyad,
                    BirimId = request.BirimId,
                    Tcno = request.Tcno,
                    SehirId = request.SehirId
                };

                _personelRepository.Add(yeniPersonel);
                _personelRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Personel başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Personel eklenirken veritabanında bir hata oluştu!",
                    ErrCode = "DB_INSERT_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse GetPersonelById(int id)
        {
            try
            {
                var personel = _personelRepository.GetById(id);

                if (personel == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Aranan personel bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                return new DtoDataResponse<DtoPersonelResponse>
                {
                    ReqCode = 200,
                    ReqMessage = "Personel başarıyla getirildi.",
                    Data = new DtoPersonelResponse
                    {
                        Ad = personel.Ad,
                        Soyad = personel.Soyad,
                        BirimAdi = personel.Birim?.BirimAdi ?? string.Empty,
                        SehirAdi = personel.Sehir?.SehirAdi ?? string.Empty
                    }
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Personel getirilirken sunucuda hata oluştu!",
                    ErrCode = "DB_READ_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse PersonelUpdate(int id, DtoPersonelRequest request)
        {
            try
            {
                var personel = _personelRepository.GetById(id);
                if (personel == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Güncellenecek personel bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                personel.Ad = request.Ad;
                personel.Soyad = request.Soyad;
                personel.Tcno = request.Tcno;
                personel.BirimId = request.BirimId;
                personel.SehirId = request.SehirId;

                _personelRepository.Update(personel);
                _personelRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Personel başarıyla güncellendi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Personel güncellenirken hata oluştu!",
                    ErrCode = "DB_UPDATE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse PersonelHardDelete(int id)
        {
            try
            {
                var personel = _personelRepository.GetById(id);
                if (personel == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Silinecek personel bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                _personelRepository.Delete(personel);
                _personelRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Personel başarıyla silindi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Personel silinirken hata oluştu!",
                    ErrCode = "DB_DELETE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse PersonelSoftDelete(int id)
        {
            try
            {
                var personel = _personelRepository.GetById(id);
                if (personel == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Silinecek personel bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                personel.Status = 0;
                _personelRepository.Update(personel);
                _personelRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Personel başarıyla pasif duruma alındı."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Personel pasife alınırken hata oluştu!",
                    ErrCode = "DB_SOFT_DELETE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }
    }
}