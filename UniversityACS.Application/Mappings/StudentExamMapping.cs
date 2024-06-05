using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings
{
    public static class StudentExamMapping
    {
        public static StudentExamDto ToDto(this StudentExam entity)
        {
            return new StudentExamDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Discipline = entity.Discipline,
                StudentId = entity.StudentId,
                TeacherId = entity.TeacherId,
                Grade = entity.Grade
            };
        }

        public static StudentExam ToEntity(this StudentExamDto dto)
        {
            return new StudentExam
            {
                Id = dto.Id,
                Name = dto.Name,
                Discipline = dto.Discipline,
                StudentId = dto.StudentId,
                TeacherId = dto.TeacherId,
                Grade = dto.Grade
            };
        }
    }
}
