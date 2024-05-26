using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;
namespace UniversityACS.Application.Services.GroupServices
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(Guid id);
        Task<Group> CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Guid id, Group group);
        Task DeleteGroupAsync(Guid id);
        Task AddTeacherToGroupAsync(Guid groupId, Guid teacherId);
        Task RemoveTeacherFromGroupAsync(Guid groupId, Guid teacherId);
    }

}
