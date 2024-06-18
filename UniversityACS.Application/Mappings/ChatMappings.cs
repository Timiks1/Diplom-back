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
                TeacherId = dto.TeacherId,
                Message = dto.Message,
                TimeCreation = dto.TimeCreation,
            };
        }

        public static void UpdateEntity(this ChatMessage entity, ChatMessageDto dto)
        {
            entity.TeacherId = dto.TeacherId;
            entity.Message = dto.Message;
            entity.TimeCreation = dto.TimeCreation;

        }

        public static ChatResponseDto ToDto(this ChatMessage entity)
        {
            return new ChatResponseDto
            {
                Id = entity.Id,
                TeacherId = entity.TeacherId,
                Message = entity.Message,
                TimeCreation = entity.TimeCreation,
                Teacher = entity.Teacher
            };
        }
    }
}
