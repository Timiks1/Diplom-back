using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Application.Services.TeacherDisciplineServices;
using UniversityACS.Application.Services.TeachingLoadServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using ClosedXML.Excel;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.TeacherLoads.Base)]
public class TeachingLoadsController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;
    private readonly ITeacherDisciplineService _treDisciplineService;
    private readonly ITeachingLoadService _teachingLoadService;
    private readonly IDisciplineService _disciplineService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "TeacherLoad.xlsx");
    public TeachingLoadsController(ITeachingLoadService teachingLoadService, IApplicationUserService applicationUserService, IDisciplineService disciplineService, ITeacherDisciplineService teacherDisciplineService)
    {
        _teachingLoadService = teachingLoadService;
        _applicationUserService = applicationUserService;
        _disciplineService = disciplineService;
        _treDisciplineService = teacherDisciplineService;
    }

    [HttpPost(ApiEndpoints.TeacherLoads.Create)]
    public async Task<ActionResult<CreateResponseDto<TeachingLoadResponseDto>>> CreateAsync(TeachingLoadDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.TeacherLoads.Update)]
    public async Task<ActionResult<UpdateResponseDto<TeachingLoadResponseDto>>> UpdateAsync(Guid id,
        TeachingLoadDto dto, CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.TeacherLoads.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.TeacherLoads.GetById)]
    public async Task<ActionResult<DetailsResponseDto<TeachingLoadResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.TeacherLoads.GetAll)]
    public async Task<ActionResult<ListResponseDto<TeachingLoadResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.TeacherLoads.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<TeachingLoadResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPost(ApiEndpoints.TeacherLoads.File)]
    public async Task<ActionResult<ListResponseDto<TeachingLoadResponseDto>>> GetFile(Guid teacherId,
       CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetByIdAsync(teacherId, cancellationToken);
        if (!response.Success)
            return NotFound();


        Console.WriteLine(templatePath);
        if (!System.IO.File.Exists(templatePath))
            return NotFound(new { ErrorMessage = "Template file not found.", StatusCode = 404 });

        using (var newWorkbook = new XLWorkbook(templatePath))
        {
            var newWorksheet = newWorkbook.Worksheet(1);
            newWorksheet.Name = response.Item.LastName;

            var teacherDisciplne = await _treDisciplineService.GetTeacherDisciplinesDto(teacherId);
            List<DisciplineDto> list = new List<DisciplineDto>();
            foreach (var item in teacherDisciplne.DisciplineIds)
            {
                var temp = await _disciplineService.GetByIdAsync(item, cancellationToken);
                list.Add(temp.Item);
            }

            newWorksheet.Cell("I4").Value = $"{response.Item.LastName} {response.Item.FirstName[0]}.";
            newWorksheet.Row(9).InsertRowsAbove(list.Count());
            for (int i = 0; i < list.Count; i++)
            {
                newWorksheet.Cell(8 + i, 1).Value = i + 1;
                newWorksheet.Cell(8 + i, 2).Value = list[i].Name;
                newWorksheet.Cell(8 + i, 5).Value = list[i].LecturerHours;
                newWorksheet.Cell(8 + i, 6).Value = list[i].Exams == "" ? "" : 2;
                newWorksheet.Cell(8 + i, 7).Value = list[i].LaboratoryHours;
                newWorksheet.Cell(8 + i, 8).Value = list[i].PracticHours;
                newWorksheet.Cell(8 + i, 16).FormulaA1 = $"=SUM(E{8 + i}:O{8 + i})";


            }



            using (var outputStream = new MemoryStream())
            {
                newWorkbook.SaveAs(outputStream);
                outputStream.Position = 0;
                return File(outputStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Навантаження викладача.xlsx");
            }
        }

    }
}