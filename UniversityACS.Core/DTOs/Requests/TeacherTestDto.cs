namespace UniversityACS.Core.DTOs.Requests;

public class TeacherTestDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public string Status { get; set; }
    public string? TestTheme { get; set; }
    public string? TestUrl { get; set; }
}