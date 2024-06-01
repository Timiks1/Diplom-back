namespace UniversityACS.Core.Entities;

public class StudentAttendance
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public ApplicationUser? Student { get; set; }
    public bool IsPresent { get; set; }
    public bool IsLate { get; set; }
    public int Grade { get; set; }
    public Guid LessonId { get; set; }
    public Lesson? Lesson { get; set; }
}