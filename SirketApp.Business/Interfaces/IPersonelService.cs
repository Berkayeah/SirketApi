using SirketApp.Business.DTOs.RequestDtos;
using SirketApp.Business.DTOs.ResponseDtos;
using System.Collections.Generic;

namespace SirketApp.Business.Services
{
	public interface IPersonelService
	{
		List<PersonelResponseDto> GetPersoneller();
		List<PersonelResponseDto> GetPersonellerDapper();

		void PersonelEkle(PersonelRequestDto request);
	}
}

