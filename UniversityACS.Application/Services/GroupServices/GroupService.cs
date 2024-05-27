using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Data.DataContext;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.GroupServices
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.Include(g => g.Students).Include(g => g.Teachers).ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(Guid id)
        {
            return await _context.Groups.Include(g => g.Students).Include(g => g.Teachers)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task UpdateGroupAsync(Guid id, Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new KeyNotFoundException("Group not found");
            }
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeacherToGroupAsync(Guid groupId, Guid teacherId)
        {
            var group = await _context.Groups.Include(g => g.Teachers).FirstOrDefaultAsync(g => g.Id == groupId);
            var teacher = await _context.Users.FindAsync(teacherId);

            if (group != null && teacher != null)
            {
                group.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveTeacherFromGroupAsync(Guid groupId, Guid teacherId)
        {
            var group = await _context.Groups.Include(g => g.Teachers).FirstOrDefaultAsync(g => g.Id == groupId);
            var teacher = group?.Teachers.FirstOrDefault(t => t.Id == teacherId);

            if (teacher != null)
            {
                group.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }
    }

}
