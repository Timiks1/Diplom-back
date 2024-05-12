﻿namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class Traineeships
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(Traineeships)}";
        
        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetByUserId = $"{Base}/{{userId:guid}}";
        public const string GetAll = Base;
    }
}