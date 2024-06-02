namespace UniversityACS.Core.DTOs.Requests;

public class StudentsGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Guid>? StudentsIds { get; set; }
}