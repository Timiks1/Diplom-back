using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ScheduleServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using System.Collections.Generic;
using System.ComponentModel;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Schedules.Base)]
public class SchedulesController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public SchedulesController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost(ApiEndpoints.Schedules.Create)]
    public async Task<ActionResult<CreateResponseDto<ScheduleResponseDto>>> CreateAsync(ScheduleDto dto, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.Schedules.Update)]
    public async Task<ActionResult<UpdateResponseDto<ScheduleResponseDto>>> UpdateAsync(Guid id, ScheduleDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _scheduleService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.Schedules.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Schedules.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ScheduleResponseDto>>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Schedules.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<ScheduleResponseDto>>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Schedules.GetAll)]
    public async Task<ActionResult<ListResponseDto<ScheduleResponseDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _scheduleService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> DownloadFileAsync(string fileName, CancellationToken cancellationToken)
    {
        var file = await _scheduleService.GetFileByNameAsync(fileName, cancellationToken);
        if (file == null)
        {
            return NotFound();
        }

        // Установка контекста лицензии
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (var memoryStream = new MemoryStream(file))
        using (var package = new ExcelPackage(memoryStream))
        {
            var worksheet = package.Workbook.Worksheets[0]; // Предполагается, что данные на первом листе
            var scheduleList = new List<ScheduleDto>();

            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                try
                {
                    var dto = new ScheduleDto
                    {
                        Date = worksheet.Cells[row, 1].GetValue<DateTime>(),
                        Lesson = worksheet.Cells[row, 2].GetValue<string>(),
                        Teacher = worksheet.Cells[row, 3].GetValue<string>(),
                        Time = worksheet.Cells[row, 4].GetValue<TimeSpan>(),
                        Description = worksheet.Cells[row, 5].GetValue<string>(),
                        TeacherId = Guid.Parse(worksheet.Cells[row, 6].GetValue<string>()), // Попробуем явно парсить как строку
                        GroupName = worksheet.Cells[row, 7].GetValue<string>()  // Новое поле

                    };
                    scheduleList.Add(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error processing row {row}: {ex.Message}");
                }
            }

            return Ok(scheduleList);
        }
    }


    [HttpPost("upload-json")]
    public async Task<IActionResult> UploadScheduleFromJsonAsync([FromQuery] string fileName, [FromBody] List<ScheduleDto> scheduleDtos, CancellationToken cancellationToken)
    {
        if (scheduleDtos == null || !scheduleDtos.Any())
        {
            return BadRequest("Invalid schedule data.");
        }

        // Установка контекста лицензии
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        var excelFileName = $"{fileName}.xlsx";
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Schedule");

            // Добавление заголовков
            worksheet.Cells[1, 1].Value = "Дата";
            worksheet.Cells[1, 2].Value = "Урок";
            worksheet.Cells[1, 3].Value = "Учитель";
            worksheet.Cells[1, 4].Value = "Время";
            worksheet.Cells[1, 5].Value = "Описание";
            worksheet.Cells[1, 6].Value = "TeacherId"; // Новый заголовок
            worksheet.Cells[1, 6].Value = "GroupName";
            worksheet.Cells[1, 8].Value = "LessonId"; // Новый заголовок
            worksheet.Cells[1, 9].Value = "StudentGroupId"; // Новый заголовок
            worksheet.Cells[1, 10].Value = "DiciplineId"; // Новый заголовок

            // Заполнение данных
            for (int i = 0; i < scheduleDtos.Count; i++)
            {
                var dto = scheduleDtos[i];
                worksheet.Cells[i + 2, 1].Value = dto.Date;
                worksheet.Cells[i + 2, 2].Value = dto.Lesson;
                worksheet.Cells[i + 2, 3].Value = dto.Teacher;
                worksheet.Cells[i + 2, 4].Value = dto.Time;
                worksheet.Cells[i + 2, 5].Value = dto.Description;
                worksheet.Cells[i + 2, 6].Value = dto.TeacherId; // Заполнение TeacherId
                worksheet.Cells[i + 2, 7].Value = dto.GroupName; // Заполнение TeacherId
                worksheet.Cells[i + 2, 8].Value = dto.LessonId; // Заполнение LessonId
                worksheet.Cells[i + 2, 9].Value = dto.StudentGroupId; // Заполнение LessonId
                worksheet.Cells[i + 2, 10].Value = dto.DisciplineId; // Заполнение LessonId

            }

            var fileBytes = package.GetAsByteArray();

            // Создание нового объекта Schedule для сохранения в базу данных
            var schedule = new ScheduleDto
            {
                Id = Guid.NewGuid(),
                Name = fileName,
                File = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, "file", excelFileName)
            };

            // Сохранение файла в базу данных
            var response = await _scheduleService.CreateAsync(schedule, cancellationToken);
            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response);
        }
    }
    // Новый метод для получения расписания по ID учителя и имени файла
    // Новый метод для получения расписания по ID учителя и имени файла
    [HttpGet("teacher-schedule")]
    public async Task<ActionResult<List<ScheduleDto>>> GetScheduleForTeacherAsync([FromQuery] string fileName, [FromQuery] Guid teacherId, CancellationToken cancellationToken)
    {
        var schedules = await _scheduleService.GetSchedulesByTeacherAsync(fileName, teacherId, cancellationToken);
        if (schedules == null)
        {
            return NotFound();
        }

        return Ok(schedules);
    }
    [HttpGet("teacher-schedule-day")]
    public async Task<ActionResult<List<ScheduleDto>>> GetScheduleForTeacherAndDayAsync([FromQuery] string fileName, [FromQuery] Guid teacherId, [FromQuery] DateTime day, CancellationToken cancellationToken)
    {
        var schedules = await _scheduleService.GetSchedulesByTeacherAndDayAsync(fileName, teacherId, day, cancellationToken);
        if (schedules == null)
        {
            return NotFound();
        }

        return Ok(schedules);
    }
    [HttpPost("add-lesson")]
    public async Task<IActionResult> AddLessonToScheduleAsync([FromQuery] string fileName, [FromBody] ScheduleDto lessonDto, CancellationToken cancellationToken)
    {
        var file = await _scheduleService.GetFileByNameAsync(fileName, cancellationToken);
        if (file == null)
        {
            return NotFound("Schedule file not found.");
        }

        // Установка контекста лицензии
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (var memoryStream = new MemoryStream(file))
        using (var package = new ExcelPackage(memoryStream))
        {
            var worksheet = package.Workbook.Worksheets[0]; // Предполагается, что данные на первом листе
            var newRow = worksheet.Dimension.End.Row + 1;

            worksheet.Cells[newRow, 1].Value = lessonDto.Date;
            worksheet.Cells[newRow, 2].Value = lessonDto.Lesson;
            worksheet.Cells[newRow, 3].Value = lessonDto.Teacher;
            worksheet.Cells[newRow, 4].Value = lessonDto.Time;
            worksheet.Cells[newRow, 5].Value = lessonDto.Description;
            worksheet.Cells[newRow, 6].Value = lessonDto.TeacherId.ToString(); // Заполнение TeacherId
            worksheet.Cells[newRow, 7].Value = lessonDto.GroupName; // Заполнение GroupName
            worksheet.Cells[newRow, 8].Value = lessonDto.LessonId.ToString(); // Заполнение LessonId
            worksheet.Cells[newRow, 9].Value = lessonDto.StudentGroupId.ToString(); // Заполнение StudentGroupId
            worksheet.Cells[newRow, 10].Value = lessonDto.DisciplineId.ToString(); // Заполнение DisciplineId

            var updatedFile = package.GetAsByteArray();

            // Обновление файла в базе данных
            var response = await _scheduleService.UpdateScheduleFileAsync(fileName, updatedFile, cancellationToken);
            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok("Lesson added successfully.");
        }
    }

}
