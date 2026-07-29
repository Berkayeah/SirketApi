using SirketApp.Business.DTOs.DtoRequests;
using SirketApp.Business.DTOs.DtoResponses;
using System.Collections.Generic;

namespace SirketApp.Business.Services
{
	public interface IPersonelService
	{
		List<DtoPersonelResponse> GetPersoneller();
		List<DtoPersonelResponse> GetPersonellerDapper();

		public DtoResponse PersonelAdd(DtoPersonelRequest request);

		public DtoResponse GetPersonelById(int id);

		public DtoResponse PersonelUpdate(int id, DtoPersonelRequest request);

		DtoResponse PersonelHardDelete(int id);
		DtoResponse PersonelSoftDelete(int id);

		List<int> GetCityCodes();
	}
}
