using Company.App.DtoRequests;
using Company.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _employeeTaskService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _employeeTaskService.GetById(id);
            if (value == null) return NotFound();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DtoEmployeeTaskRequest request)
        {
            _employeeTaskService.Add(request);
            return Ok(new { message = "İşlem başarıyla eklendi." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DtoEmployeeTaskRequest request)
        {
            _employeeTaskService.Update(id, request);
            return Ok(new { message = "İşlem başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeTaskService.Delete(id);
            return Ok(new { message = "İşlem başarıyla silindi." });
        }
    }
}