namespace UniversityACS.Core.Entities;

public class TeacherTest
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
    public string Status { get; set; }
    public string? TestTheme { get; set; }
    public string? TestUrl { get; set; }
}