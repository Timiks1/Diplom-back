using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.DTOs;

namespace UniversityACS.Application.Services.ChatServices
{
    public interface IChatService
    {
        Task<CreateResponseDto<ChatMessageDto>> CreateAsync(ChatMessageDto dto,
       CancellationToken cancellationToken = default!);

        Task<ListResponseDto<ChatResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
        Task<ListResponseDto<ChatResponseDto>> GetChatHistoryAsync(Guid currentUserId, Guid otherUserId, CancellationToken cancellationToken = default);
        Task<ListResponseDto<ChatResponseDto>> GetUserChatsAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
