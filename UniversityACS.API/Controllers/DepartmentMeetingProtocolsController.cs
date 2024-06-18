using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DepartmentMeetingProtocolServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.DepartmentMeetingProtocols.Base)]
public class DepartmentMeetingProtocolsController : ControllerBase
{
    private readonly IDepartmentMeetingProtocolService _meetingProtocolService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Protocol.docx");
    public DepartmentMeetingProtocolsController(IDepartmentMeetingProtocolService meetingProtocolService)
    {
        _meetingProtocolService = meetingProtocolService;
    }


    [HttpPost(ApiEndpoints.DepartmentMeetingProtocols.Create)]
    public async Task<ActionResult<CreateResponseDto<DepartmentMeetingProtocolDto>>> CreateAsync(Guid departmentId, CancellationToken cancellationToken)
    {

        DepartmentMeetingProtocolDto dto = new DepartmentMeetingProtocolDto();
        dto.DepartmentId = departmentId;
        dto.Name = $"Протокол.docx";
        byte[] fileBytes = System.IO.File.ReadAllBytes(templatePath);
        MemoryStream memoryStream = new MemoryStream(fileBytes);
        dto.File = new FormFile(memoryStream, 0, memoryStream.Length, Path.GetFileName(templatePath), Path.GetFileName(templatePath));
        await _meetingProtocolService.CreateAsync(dto, cancellationToken);

        memoryStream.Position = 0;
        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Протокол.docx");
    }

    [HttpPut(ApiEndpoints.DepartmentMeetingProtocols.Update)]
    public async Task<ActionResult<UpdateResponseDto<DepartmentMeetingProtocolDto>>> UpdateAsync(Guid id,
        DepartmentMeetingProtocolDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _meetingProtocolService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.DepartmentMeetingProtocols.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _meetingProtocolService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingProtocols.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DepartmentMeetingProtocolResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _meetingProtocolService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingProtocols.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingProtocolResponseDto>>> GetByDepartmentIdAsync(
        Guid departmentId, CancellationToken cancellationToken)
    {
        var response = await _meetingProtocolService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DepartmentMeetingProtocols.GetAll)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingProtocolResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _meetingProtocolService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}