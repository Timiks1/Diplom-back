using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.GroupServices;
using UniversityACS.Core.Entities;
namespace UniversityACS.API.Controllers
{
    [ApiController]
    [Route(ApiEndpoints.Groups.Base)]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [Route(ApiEndpoints.Groups.GetAll)]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            return Ok(groups);
        }

        [HttpGet]
        [Route(ApiEndpoints.Groups.GetById)]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost]
        [Route(ApiEndpoints.Groups.Create)]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            var createdGroup = await _groupService.CreateGroupAsync(group);
            return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.Id }, createdGroup);
        }

        [HttpPut]
        [Route(ApiEndpoints.Groups.Update)]
        public async Task<IActionResult> PutGroup(Guid id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            try
            {
                await _groupService.UpdateGroupAsync(id, group);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiEndpoints.Groups.Delete)]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            try
            {
                await _groupService.DeleteGroupAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Route(ApiEndpoints.Groups.AddTeacher)]
        public async Task<IActionResult> AddTeacherToGroup(Guid groupId, Guid teacherId)
        {
            try
            {
                await _groupService.AddTeacherToGroupAsync(groupId, teacherId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route(ApiEndpoints.Groups.RemoveTeacher)]
        public async Task<IActionResult> RemoveTeacherFromGroup(Guid groupId, Guid teacherId)
        {
            try
            {
                await _groupService.RemoveTeacherFromGroupAsync(groupId, teacherId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task<bool> GroupExists(Guid id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            return group != null;
        }
    }
}
