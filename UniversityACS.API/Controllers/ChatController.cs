using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Mappings;
using UniversityACS.Application.Services.ChatServices;
using UniversityACS.Application.Services.ReviewServices;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route(ApiEndpoints.Reviews.Base)]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [Route(ApiEndpoints.Chat.Create)]
        public async Task<IActionResult> AddMessage([FromBody] ChatMessageDto message)
        {
            if (message == null)
            {
                return BadRequest("Review data is null.");
            }

            try
            {
                var addedReview = await _chatService.CreateAsync(message);
                return Ok(addedReview);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route(ApiEndpoints.Chat.GetAll)]
        public async Task<IActionResult> GetMessages()
        {
            var reviews = await _chatService.GetAllAsync();
            return Ok(reviews);
        }
        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> GetChatHistory([FromQuery] Guid currentUserId, [FromQuery] Guid otherUserId)
        {
            var messages = await _chatService.GetChatHistoryAsync(currentUserId, otherUserId);
            return Ok(messages);
        }
        [HttpGet]
        [Route("userChats")]
        public async Task<IActionResult> GetUserChats([FromQuery] Guid userId)
        {
            var chats = await _chatService.GetUserChatsAsync(userId);
            return Ok(chats);
        }
    }
}
