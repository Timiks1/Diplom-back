namespace UniversityACS.Core.Entities;

public class Discipline
{
    public Guid Id { get; set; }

    public List<ApplicationUser>? Teachers { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? FieldOfStudy { get; set; }
    public string? Description { get; set; }
    public int? ECTS { get; set; }
    public int? LecturerHours { get; set; }
    public int? PracticHours { get; set; }
    public int? LaboratoryHours { get; set; }
    public int? IndependentHours { get; set; }

    public string? Tests { get; set; }
    public string? Exams { get; set; }
    public string? AuditoryTasks { get; set; }
    public List<string>? Courses { get; set; }

}