using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.AttendanceServices;
using UniversityACS.Core.Entities;

namespace UniversityACS.API.Controllers
{
    [Route("api/[controller]")]
    [Route(ApiEndpoints.Attendance.Base)]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost(ApiEndpoints.Attendance.Create)]

        public async Task<IActionResult> Create([FromBody] Lesson lesson)
        {
            if (lesson == null)
            {
                return BadRequest("Lesson data is null.");
            }

            try
            {
                await _attendanceService.Create(lesson);
                return Ok("Attendance recorded successfully.");
            }
            catch (Exception ex)
            {
                // Логгирование ошибки (если необходимо)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
