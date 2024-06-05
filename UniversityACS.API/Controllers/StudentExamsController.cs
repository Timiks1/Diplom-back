using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.Application.Services.StudentExamService;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamsController : ControllerBase
    {
        private readonly IStudentExamService _studentExamService;

        public StudentExamsController(IStudentExamService studentExamService)
        {
            _studentExamService = studentExamService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentExamDto dto, CancellationToken cancellationToken)
        {
            var result = await _studentExamService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StudentExamDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentExamService.UpdateAsync(id, dto, cancellationToken);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await _studentExamService.DeleteAsync(id, cancellationToken);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _studentExamService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _studentExamService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpGet("by-discipline/{disciplineId}")]
        public async Task<IActionResult> GetByDisciplineId(Guid disciplineId, CancellationToken cancellationToken)
        {
            var result = await _studentExamService.GetByDisciplineIdAsync(disciplineId, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
