namespace UniversityACS.Core.Entities;

public class Lesson
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? SubjectName { get; set; }
    public string? LessonName { get; set; }
    public Guid TeacherId { get; set; }
    public Guid HomeWorkId { get; set; }

    public ApplicationUser? Teacher { get; set; }
    public HomeWork? HomeWork { get; set; }

    public List<StudentAttendance>? StudentAttendances { get; set; }
}