using Microsoft.AspNetCore.Mvc;
using SirketApp.Business.Services;
using SirketApp.Business.DTOs.DtoRequests;
using SirketApp.Business.DTOs.DtoResponses;

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

		[HttpPost]
		public IActionResult Add([FromBody] DtoPersonelRequest request)
		{
            DtoResponse response = _personelService.PersonelAdd(request);

            if (response.ReqCode == 200)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DtoResponse response = _personelService.GetPersonelById(id);

            return response.ReqCode == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DtoPersonelRequest request)
        {
            DtoResponse response = _personelService.PersonelUpdate(id, request);
            return response.ReqCode == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("hard/{id}")]
        public IActionResult HardDelete(int id)
        {
            var response = _personelService.PersonelHardDelete(id);
            if(response.ReqCode != 200)
            {
                return StatusCode(response.ReqCode, response);
            }
            return Ok(response);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var response = _personelService.PersonelSoftDelete(id);
            if(response.ReqCode != 200)
            {
                return StatusCode(response.ReqCode, response);
            }
            return Ok(response);
        }

        [HttpGet("city-codes")]
        public IActionResult GetBenzersizSehirKodlari()
        {
            var codes = _personelService.GetCityCodes();
            return Ok(codes);
        }
    }
}
