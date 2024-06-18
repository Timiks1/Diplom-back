using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Application.Services.IndividualPlanServices;
using UniversityACS.Application.Services.TeacherDisciplineServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.IndividualPlans.Base)]
public class IndividualPlansController : ControllerBase
{
    private readonly IIndividualPlanService _individualPlanService;
    private readonly IDisciplineService _disciplinesService;
    private readonly ITeacherDisciplineService _treDisciplineService;
    private readonly IApplicationUserService _applicationUserService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "IndividualPlans.xlsx");

    public IndividualPlansController(IIndividualPlanService individualPlanService, IApplicationUserService applicationUserService, IDisciplineService disciplineService, ITeacherDisciplineService teacherDisciplineService)
    {
        _individualPlanService = individualPlanService;
        _applicationUserService = applicationUserService;
        _disciplinesService = disciplineService;
        _treDisciplineService = teacherDisciplineService;
    }


    [HttpPost(ApiEndpoints.IndividualPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<IndividualPlanResponseDto>>> CreateAsync(IndividualPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.IndividualPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<IndividualPlanResponseDto>>> UpdateAsync(Guid id,
        IndividualPlanDto dto, CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.IndividualPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<IndividualPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<IndividualPlanResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<IndividualPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPost(ApiEndpoints.IndividualPlans.File)]
    public async Task<ActionResult> GetFile(int year, Guid teacherId, CancellationToken cancellationToken)
    {
        try
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


                var disciplines = (await _disciplinesService.GetAllAsync()).Items;

                newWorksheet.Cell("B21").Value = $"на 20{year} / 20{year + 1} навчальний рік";
                newWorksheet.Cell("D30").Value = $"{response.Item.LastName} {response.Item.FirstName} {response.Item.Patronymic}";

                var secondWorksheet = newWorkbook.Worksheet(2);
                var teacherDisciplne = await _treDisciplineService.GetTeacherDisciplinesDto(teacherId);
                List<DisciplineDto> list = new List<DisciplineDto>();
                foreach (var item in teacherDisciplne.DisciplineIds)
                {
                    var temp = await _disciplinesService.GetByIdAsync(item, cancellationToken);
                    list.Add(temp.Item);
                }

                for (int j = 0; j < 2; j++)
                {
                    var first = list.Where(x => x.Exams.Contains($"{1 + j}") || x.Exams.Contains($"{3 + j}") || x.Exams.Contains($"{5 + j}") || x.Exams.Contains($"{7 + j}") ||
                        x.Tests.Contains($"{1 + j}") || x.Tests.Contains($"{3 + j}") || x.Tests.Contains($"{5 + j}") || x.Tests.Contains($"{7 + j}")
                    ).ToList();



                    for (int i = 0; i < first.Count && i < 13; i++)
                    {
                        secondWorksheet.Cell(j * 14 + 6 + i, 1).Value = i + 1;
                        secondWorksheet.Cell(j * 14 + 6 + i, 2).Value = first[i].Name;
                        secondWorksheet.Cell(j * 14 + 6 + i, 4).Value = first[i].LecturerHours;
                        secondWorksheet.Cell(j * 14 + 6 + i, 5).Value = 0;
                        secondWorksheet.Cell(j * 14 + 6 + i, 6).Value = first[i].LaboratoryHours;
                        secondWorksheet.Cell(j * 14 + 6 + i, 7).Value = 0;
                        secondWorksheet.Cell(j * 14 + 6 + i, 8).Value = first[i].PracticHours;
                        secondWorksheet.Cell(j * 14 + 6 + i, 9).Value = 0;
                        if (first[i].Exams == "")
                        {
                            secondWorksheet.Cell(j * 14 + 6 + i, 22).Value = 2;
                            secondWorksheet.Cell(j * 14 + 6 + i, 23).Value = 0;

                        }
                    }

                }
                using (var outputStream = new MemoryStream())
                {
                    newWorkbook.SaveAs(outputStream);

                    IndividualPlanDto individualDto = new IndividualPlanDto();
                    individualDto.Name = $"Індивідуальний план 20{year} / 20{year + 1}.xlsx";
                    individualDto.TeacherId = teacherId;


                    outputStream.Position = 0;

                    var formFile = new FormFile(outputStream, 0, outputStream.Length, "file", "Індивідуальний план.xlsx")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/zip"
                    };
                    individualDto.File = formFile;
                    var response2 = await _individualPlanService.CreateAsync(individualDto, cancellationToken);
                    if (!response2.Success)
                    {
                        return BadRequest(response2);
                    }

                    outputStream.Position = 0;
                    return File(outputStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Індивідуальний план.xlsx");
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { ErrorMessage = "An unexpected error occurred.", StatusCode = 500, Element = ex.Message });
        }
    }
}