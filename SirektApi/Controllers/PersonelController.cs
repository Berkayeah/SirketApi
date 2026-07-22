using Microsoft.AspNetCore.Mvc;
using SirketApp.Business;

namespace SirektApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class PersonelController : ControllerBase
	{
		private readonly IPersonelService _personelService;
		public PersonelController(IPersonelService personelService)
		{
			_personelService = personelService;
		}

		[HttpGet]
		public IActionResult GetPersoneller()
		{
			var personeller = _personelService.GetPersoneller();

			return Ok(personeller);
		}

		[HttpGet("dapper-liste")]
		public IActionResult GetPersonellerDapper()
		{
			var personeller = _personelService.GetPersonellerDapper();
			return Ok(personeller);

		}
	}
}
