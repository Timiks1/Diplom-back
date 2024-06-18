
using UniversityACS.Core.Entities;
using static UniversityACS.API.Endpoints.ApiEndpoints;

namespace UniversityACS.API.Endpoints;


public static partial class ApiEndpoints
{
    public static class Chat
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(ChatMessage)}";
        public const string Create = Base;
        public const string GetAll = Base;
    }

}


