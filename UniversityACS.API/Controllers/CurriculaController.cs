using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.CurriculumServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Curricula.Base)]
public class CurriculaController : ControllerBase
{

    private readonly ICurriculumService _curriculumService;
    private readonly IDisciplineService _disciplinesService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Curricula.xlsx");

    public CurriculaController(ICurriculumService curriculumService, IDisciplineService disciplinesService)
    {
        _curriculumService = curriculumService;
        _disciplinesService = disciplinesService;
    }

    [HttpPost(ApiEndpoints.Curricula.Create)]
    public async Task<ActionResult<CreateResponseDto<CurriculumDto>>> CreateAsync(CurriculumDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.Curricula.Update)]
    public async Task<ActionResult<UpdateResponseDto<CurriculumDto>>> UpdateAsync(Guid id, CurriculumDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.Curricula.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Curricula.GetById)]
    public async Task<ActionResult<DetailsResponseDto<CurriculumResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Curricula.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<CurriculumResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Curricula.GetAll)]
    public async Task<ActionResult<ListResponseDto<CurriculumResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPost(ApiEndpoints.Curricula.Process)]
    public async Task<ActionResult> Process(int semester)
    {
        try
        {

            Console.WriteLine(templatePath);
            if (!System.IO.File.Exists(templatePath))
                return NotFound(new { ErrorMessage = "Template file not found.", StatusCode = 404 });

            using (var newWorkbook = new XLWorkbook(templatePath))
            {
                var newWorksheet = newWorkbook.Worksheet(1);


                var disciplines = (await _disciplinesService.GetAllAsync()).Items;
                if (semester == 1)
                {
                    newWorksheet.Cell("D10").Value = "(Перший семестр)";

                    int currentRow = 13;
                    for (int k = 0; k < 4; k++)
                    {
                        var firstcourse = disciplines.Where(discipline => discipline.Exams.Contains($"{k * 2 + 1}") || discipline.Tests.Contains($"{k * 2 + 1}")).ToList();
                        for (int i = 0; i < firstcourse.Count(); i++)
                        {

                            newWorksheet.Cell(i + currentRow, 1).Value = firstcourse[i].Name;
                            newWorksheet.Cell(i + currentRow, 4).Value = k * 2 + 1;
                            newWorksheet.Cell(i + currentRow, 8).Value = firstcourse[i].LecturerHours;
                            newWorksheet.Cell(i + currentRow, 9).Value = firstcourse[i].PracticHours;
                            newWorksheet.Cell(i + currentRow, 10).Value = firstcourse[i].LaboratoryHours;
                            newWorksheet.Cell(i + currentRow, 5).Value = firstcourse[i].Exams == "" ? "" : 2;
                            newWorksheet.Cell(i + currentRow, 6).Value = firstcourse[i].Tests == "" ? "" : 0;
                            newWorksheet.Cell(i + currentRow, 11).Value = firstcourse[i].Exams == "" ? 0 : 2;
                            newWorksheet.Cell(i + currentRow, 12).FormulaA1 = $"=SUM(H{i + currentRow}:K{i + currentRow}) + E{i + currentRow}";
                        }
                        for (int i = 13; i >= firstcourse.Count(); i--)
                        {
                            newWorksheet.Row(i + currentRow).Delete();
                        }
                        currentRow += firstcourse.Count() + 2;
                    }

                }
                else
                {
                    newWorksheet.Cell("D10").Value = "(Другий семестр)";

                    int currentRow = 13;
                    for (int k = 0; k < 4; k++)
                    {
                        var firstcourse = disciplines.Where(discipline => discipline.Exams.Contains($"{((k + 1) * 2)}") || discipline.Tests.Contains($"{((k + 1) * 2)}")).ToList();
                        for (int i = 0; i < firstcourse.Count(); i++)
                        {

                            newWorksheet.Cell(i + currentRow, 1).Value = firstcourse[i].Name;
                            newWorksheet.Cell(i + currentRow, 4).Value = (k + 1) * 2;
                            newWorksheet.Cell(i + currentRow, 8).Value = firstcourse[i].LecturerHours;
                            newWorksheet.Cell(i + currentRow, 9).Value = firstcourse[i].PracticHours;
                            newWorksheet.Cell(i + currentRow, 10).Value = firstcourse[i].LaboratoryHours;
                            newWorksheet.Cell(i + currentRow, 5).Value = firstcourse[i].Exams == "" ? "" : 2;
                            newWorksheet.Cell(i + currentRow, 6).Value = firstcourse[i].Tests == "" ? "" : 0;
                            newWorksheet.Cell(i + currentRow, 11).Value = firstcourse[i].Exams == "" ? 0 : 2;
                            newWorksheet.Cell(i + currentRow, 12).FormulaA1 = $"=SUM(H{i + currentRow}:K{i + currentRow}) + E{i + currentRow}";

                        }
                        for (int i = 13; i >= firstcourse.Count(); i--)
                        {
                            newWorksheet.Row(i + currentRow).Delete();
                        }
                        currentRow += firstcourse.Count() + 2;
                    }

                }
                using (var outputStream = new MemoryStream())
                {
                    newWorkbook.SaveAs(outputStream);
                    outputStream.Position = 0;
                    return File(outputStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "План навчального навантаження.xlsx");
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { ErrorMessage = "An unexpected error occurred.", StatusCode = 500, Element = ex.Message });
        }
    }
}