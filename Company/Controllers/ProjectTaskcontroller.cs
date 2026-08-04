using Company.Application.DtoRequests;
using Company.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _projectTaskService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _projectTaskService.GetById(id);
            if (value == null) return NotFound();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DtoProjectTaskRequest request)
        {
            _projectTaskService.Add(request);
            return Ok(new { message = "Görev başarıyla eklendi." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DtoProjectTaskRequest request)
        {
            _projectTaskService.Update(id, request);
            return Ok(new { message = "Görev başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectTaskService.Delete(id);
            return Ok(new { message = "Görev başarıyla silindi." });
        }
    }
}