using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DepartmentMeetingPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.DepartmentMeetingPlans.Base)]
public class DepartmentMeetingPlansController : ControllerBase
{
    private readonly IDepartmentMeetingPlanService _meetingPlanService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ScheduleMeetings.docx");
    public DepartmentMeetingPlansController(IDepartmentMeetingPlanService meetingPlanService)
    {
        _meetingPlanService = meetingPlanService;
    }

    [HttpPost(ApiEndpoints.DepartmentMeetingPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<DepartmentMeetingProtocolDto>>> CreateAsync(Guid departmentId, CancellationToken cancellationToken)
    {

        DepartmentMeetingPlanDto dto = new DepartmentMeetingPlanDto();
        dto.DepartmentId = departmentId;
        dto.Name = $"Графік проведення засідань.docx";
        byte[] fileBytes = System.IO.File.ReadAllBytes(templatePath);
        MemoryStream memoryStream = new MemoryStream(fileBytes);
        dto.File = new FormFile(memoryStream, 0, memoryStream.Length, Path.GetFileName(templatePath), Path.GetFileName(templatePath));
        await _meetingPlanService.CreateAsync(dto, cancellationToken);

        memoryStream.Position = 0;
        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Графік проведення засідань.docx");
    }

    [HttpPut(ApiEndpoints.DepartmentMeetingPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<DepartmentMeetingPlanDto>>> UpdateAsync(Guid id,
        DepartmentMeetingPlanDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.DepartmentMeetingPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DepartmentMeetingPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingPlanResponseDto>>> GetByDepartmentIdAsync(
        Guid departmentId, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}