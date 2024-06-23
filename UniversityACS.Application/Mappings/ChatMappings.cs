using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings
{
    public static class ChatMappings
    {
        public static ChatMessage ToEntity(this ChatMessageDto dto)
        {
            return new ChatMessage
            {
                Id = dto.Id,
                Message = dto.Message,
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                TimeCreation = dto.TimeCreation,
            };
        }

        public static void UpdateEntity(this ChatMessage entity, ChatMessageDto dto)
        {
            entity.Message = dto.Message;
            entity.SenderId = dto.SenderId;
            entity.ReceiverId = dto.ReceiverId;
            entity.TimeCreation = dto.TimeCreation;
        }

        public static ChatResponseDto ToDto(this ChatMessage entity)
        {
            return new ChatResponseDto
            {
                Id = entity.Id,
                Message = entity.Message,
                SenderId = entity.SenderId,
                ReceiverId = entity.ReceiverId,
                TimeCreation = entity.TimeCreation,
                SenderName = entity.Sender.FirstName,
                ReceiverName = entity.Receiver.FirstName,
            };
        }
    }
}
