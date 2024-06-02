namespace UniversityACS.Core.Entities;

public class Discipline
{
    public Guid Id { get; set; }

    public List<ApplicationUser>? Teachers { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? FieldOfStudy { get; set; }
    public string? Description { get; set; }
    public List<string>? Courses { get; set; }
    public List<StudentsGroup>? StudentsGroups { get; set; }

}