using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.DTOs.Requests
{
    public class SyllabusDataDto
    {
        public string Literature { get; set; }
        public string AdditionalInfo { get; set; }
        public string TeacherInfo { get; set; }
        public string Prerequisites { get; set; }
        public string Corequisites { get; set; }
        public string DisciplineGoal { get; set; }
        public string DisciplineContent { get; set; }
        public string IndividualTasks { get; set; }
        public string Software { get; set; }
        public string StudyResults { get; set; }
    }
}
