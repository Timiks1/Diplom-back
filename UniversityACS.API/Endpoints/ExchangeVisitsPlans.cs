namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class ExchangeVisitsPlans
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(ExchangeVisitsPlans)}";

        public const string Create = Base;
        public const string CreateFile = $"{Base}/createFile";

        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetByUserId = $"{Base}/{nameof(GetByUserId)}/{{userId:guid}}";
        public const string GetAll = Base;
    }
}