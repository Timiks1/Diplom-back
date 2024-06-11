using System;
using System.Collections.Generic;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Requests
{
    public class DisciplineDto
    {
        public Guid Id { get; set; }
        public List<ApplicationUser>? Teachers { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? FieldOfStudy { get; set; }
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
}
