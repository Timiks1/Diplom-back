using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateResponseDto<ChatMessageDto>> CreateAsync(ChatMessageDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.ToEntity();



            await _context.Chat.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateResponseDto<ChatMessageDto>()
            {
                Success = true,
                Id = entity.Id
            };
        }



        public async Task<ListResponseDto<ChatResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.Chat
           .ToListAsync(cancellationToken);
            entities.ForEach(entities => { entities.Teacher = _context.ApplicationUsers.Where(x => x.Id == entities.TeacherId).ToList()[0]; });

            return new ListResponseDto<ChatResponseDto>()
            {
                Success = true,
                Items = entities.Select(x => x.ToDto()).ToList(),
                TotalCount = entities.Count
            };
        }

    }
}
