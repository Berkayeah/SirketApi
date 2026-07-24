using SirketApp.Business.DTOs.DtoRequests;
using SirketApp.Business.DTOs.DtoResponses;
using System.Collections.Generic;

namespace SirketApp.Business.Services
{
	public interface IPersonelService
	{
		List<DtoPersonelResponse> GetPersoneller();
		List<DtoPersonelResponse> GetPersonellerDapper();

		public DtoResponse PersonelEkle(DtoPersonelRequest request);

		public DtoResponse GetPersonelById(int id);

		public DtoResponse PersonelGuncelle(int id, DtoPersonelRequest request);

		public DtoResponse PersonelSil(int id);
	}
}

