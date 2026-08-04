using Microsoft.AspNetCore.Mvc;
using Company.Application.Services;
using Company.Application.DTOs.DtoRequests;
using Company.Application.DTOs.DtoResponses;

namespace SirektApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        public IActionResult GetEmployeeler()
        {
            var Employeeler = _EmployeeService.GetEmployees();

            return Ok(Employeeler);
        }

        [HttpGet("dapper-list")]
        public IActionResult GetEmployeelerDApplicationlicationer()
        {
            var Employeeler = _EmployeeService.GetEmployeesDapper();
            return Ok(Employeeler);

        }

        [HttpPost]
        public IActionResult Add([FromBody] DtoEmployeeRequest request)
        {
            DtoResponse response = _EmployeeService.EmployeeAdd(request);

            if (response.ReqCode == 200)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DtoResponse response = _EmployeeService.GetEmployeeById(id);

            return response.ReqCode == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DtoEmployeeRequest request)
        {
            DtoResponse response = _EmployeeService.EmployeeUpdate(id, request);
            return response.ReqCode == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("hard/{id}")]
        public IActionResult HardDelete(int id)
        {
            var response = _EmployeeService.EmployeeHardDelete(id);
            if (response.ReqCode != 200)
            {
                return StatusCode(response.ReqCode, response);
            }
            return Ok(response);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var response = _EmployeeService.EmployeeSoftDelete(id);
            if (response.ReqCode != 200)
            {
                return StatusCode(response.ReqCode, response);
            }
            return Ok(response);
        }

        [HttpGet("city-codes")]
        public IActionResult GetBenzersizCityKodlari()
        {
            var codes = _EmployeeService.GetCityCodes();
            return Ok(codes);
        }
    }
}
