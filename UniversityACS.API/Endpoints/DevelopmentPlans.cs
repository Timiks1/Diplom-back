namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class DevelopmentPlans
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(DevelopmentPlans)}";

        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetByUserId = $"{Base}/{nameof(GetByUserId)}/{{userId:guid}}";
        public const string GetAll = Base;
        public const string Upload = $"{Base}/upload";
        public const string Plan = $"{Base}/plan";
    }
}