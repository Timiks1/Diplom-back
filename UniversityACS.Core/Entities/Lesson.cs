using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string SubjectName { get; set; }
        public string LessonName { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<StudentAttendance> StudentAttendances { get; set; }
    }
}
