using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.StudentAttendanceServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.StudentAttendances.Base)]
public class StudentAttendancesController : ControllerBase
{
    private readonly IStudentAttendanceService _studentAttendanceService;

    public StudentAttendancesController(IStudentAttendanceService studentAttendanceService)
    {
        _studentAttendanceService = studentAttendanceService;
    }

    [HttpPost(ApiEndpoints.StudentAttendances.Create)]
    public async Task<ActionResult<CreateResponseDto<StudentAttendanceDto>>> CreateAsync(StudentAttendanceDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.StudentAttendances.Update)]
    public async Task<ActionResult<UpdateResponseDto<StudentAttendanceDto>>> UpdateAsync(Guid id,
        StudentAttendanceDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.StudentAttendances.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.StudentAttendances.GetById)]
    public async Task<ActionResult<DetailsResponseDto<StudentAttendanceDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.StudentAttendances.GetByStudentId)]
    public async Task<ActionResult<ListResponseDto<StudentAttendanceDto>>> GetByStudentIdAsync(Guid studentId,
        CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.GetByStudentIdAsync(studentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.StudentAttendances.GetAll)]
    public async Task<ActionResult<ListResponseDto<StudentAttendanceDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _studentAttendanceService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}