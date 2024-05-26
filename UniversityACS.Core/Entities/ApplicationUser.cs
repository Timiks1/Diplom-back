using Microsoft.AspNetCore.Identity;

namespace UniversityACS.Core.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DepartmentEmail { get; set; }
    public string? Address { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Group>? Groups { get; set; } = new List<Group>();
    public List<Discipline>? Disciplines { get; set; }
    public List<Syllabus>? Syllabi { get; set; }
    public Traineeship? Traineeship { get; set; }
    public ScientificAndPedagogicalActivity? ScientificAndPedagogicalActivity { get; set; }
}