using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace UniversityACS.API.Middleware;

public class AppExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public AppExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    private ErrorResponse GetErrorResponseDto(Exception ex)
    {
        var errorResponseDto = new ErrorResponse
        {
            ErrorMessage = ex.Message,
            StatusCode = 500,
            Element = "unknown",
            Id = "unknown"
        };

        switch (ex)
        {
            case DbUpdateException dbUpdateException:
                errorResponseDto.ErrorMessage = dbUpdateException.InnerException?.Message;
                errorResponseDto.StatusCode = 400;
                break;

            default:
                errorResponseDto.ErrorMessage = ex.Message;
                errorResponseDto.StatusCode = 400;
                errorResponseDto.Element = "unknown";
                errorResponseDto.Id = "unknown";
                break;
        }

        return errorResponseDto;
    }

    private async Task WriteDtoInResponse(HttpContext context, ErrorResponse response)
    {
        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = "application/json";
        var jsonResponse = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(jsonResponse);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            await _next(context);
        }
        catch (Exception ex)
        {
            await WriteDtoInResponse(context, GetErrorResponseDto(ex));
        }
    }
}

public class ErrorResponse
{
    public string ErrorMessage { get; set; }
    public int StatusCode { get; set; }
    public string Element { get; set; }
    public string Id { get; set; }
}