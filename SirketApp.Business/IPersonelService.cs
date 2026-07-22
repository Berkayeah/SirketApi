using SirketApp.Business.DTOs;
using System.Collections.Generic;

namespace SirketApp.Business
{
	public interface IPersonelService
	{
		List<PersonelDetayDto> GetPersoneller();
		List<PersonelDetayDto> GetPersonellerDapper();
	}
}

