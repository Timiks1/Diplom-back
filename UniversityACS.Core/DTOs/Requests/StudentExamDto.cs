using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.DTOs.Requests
{
    public class StudentExamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid Discipline { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public float? Grade { get; set; }
    }
}
