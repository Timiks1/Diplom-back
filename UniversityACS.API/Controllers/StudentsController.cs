using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.StudentsServices;
using UniversityACS.Core.Entities;

namespace UniversityACS.API.Controllers
{
    [ApiController]
    [Route(ApiEndpoints.Students.Base)]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route(ApiEndpoints.Students.GetAll)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet]
        [Route(ApiEndpoints.Students.GetById)]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet]
        [Route(ApiEndpoints.Students.GetByGroup)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByGroup(Guid groupId)
        {
            var students = await _studentService.GetStudentsByGroupAsync(groupId);
            return Ok(students);
        }
        [HttpPost]
        [Route(ApiEndpoints.Students.Create)]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var createdStudent = await _studentService.CreateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut]
        [Route(ApiEndpoints.Students.Update)]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studentService.UpdateStudentAsync(id, student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiEndpoints.Students.Delete)]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> StudentExists(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return student != null;
        }
    }
}
