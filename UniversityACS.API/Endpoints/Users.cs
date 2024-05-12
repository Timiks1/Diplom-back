﻿namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class Users
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(Users)}";
        
        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetByDepartmentId = $"{Base}/{{departmentId:guid}}";
        public const string GetAll = Base;
        public const string ChangePassword = $"{Base}/{nameof(ChangePassword)}";
    }
}