using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;
using UniversityACS.Application.Mappings;

namespace UniversityACS.Application.Services.StudentExamService
{
    public class StudentExamService : IStudentExamService
    {
        private readonly ApplicationDbContext _context;

        public StudentExamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentExamDto> CreateAsync(StudentExamDto dto, CancellationToken cancellationToken = default)
        {
            var entity = new StudentExam
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Discipline = dto.Discipline,
                StudentId = dto.StudentId,
                TeacherId = dto.TeacherId,
                Grade = dto.Grade
            };

            await _context.StudentExams.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

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

        public async Task<StudentExamDto> UpdateAsync(Guid id, StudentExamDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _context.StudentExams.FindAsync(new object[] { id }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException("Student exam not found");
            }

            entity.Name = dto.Name;
            entity.Discipline = dto.Discipline;
            entity.StudentId = dto.StudentId;
            entity.TeacherId = dto.TeacherId;
            entity.Grade = dto.Grade;

            _context.StudentExams.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return dto;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.StudentExams.FindAsync(new object[] { id }, cancellationToken);

            if (entity == null)
            {
                return false;
            }

            _context.StudentExams.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<StudentExamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.StudentExams.FindAsync(new object[] { id }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException("Student exam not found");
            }

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

        public async Task<IEnumerable<StudentExamDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StudentExams
                .Select(entity => new StudentExamDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Discipline = entity.Discipline,
                    StudentId = entity.StudentId,
                    TeacherId = entity.TeacherId,
                    Grade = entity.Grade
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<List<StudentExamDto>> GetByDisciplineIdAsync(Guid disciplineId, CancellationToken cancellationToken = default)
        {
            var entities = await _context.StudentExams
                .Where(se => se.Discipline == disciplineId)
                .ToListAsync(cancellationToken);

            return entities.Select(e => e.ToDto()).ToList();
        }
    }
}
