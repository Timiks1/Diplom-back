namespace UniversityACS.Core.DTOs.Responses;

public class ApplicationUserResponseDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? DepartmentEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DepartmentName { get; set; }
    public string? GroupName { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? GroupId { get; set; }
}