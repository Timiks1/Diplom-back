using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UniversityACS.API.Services.Identity;
using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Application.Services.AttendanceServices;
using UniversityACS.Application.Services.CertificationReportServices;
using UniversityACS.Application.Services.CurriculumServices;
using UniversityACS.Application.Services.DepartmentMeetingPlanServices;
using UniversityACS.Application.Services.DepartmentMeetingProtocolServices;
using UniversityACS.Application.Services.DepartmentServices;
using UniversityACS.Application.Services.DevelopmentPlanServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Application.Services.ExchangeVisitPlanServices;
using UniversityACS.Application.Services.ExchangeVisitsPlanReviewServices;
using UniversityACS.Application.Services.HomeWorkServices;
using UniversityACS.Application.Services.IndividualPlanServices;
using UniversityACS.Application.Services.LessonServices;
using UniversityACS.Application.Services.NewsServices;
using UniversityACS.Application.Services.ReviewServices;
using UniversityACS.Application.Services.ScheduleServices;
using UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;
using UniversityACS.Application.Services.StatementServices;
using UniversityACS.Application.Services.StudentAttendanceServices;
using UniversityACS.Application.Services.StudentExamService;
using UniversityACS.Application.Services.StudentsGroupServices;
using UniversityACS.Application.Services.SubmissionToCertificationThemesServices;
using UniversityACS.Application.Services.SubmissionToTheCommitteeServices;
using UniversityACS.Application.Services.SubmissionToTheHeadOfCommitteeServices;
using UniversityACS.Application.Services.SyllabusServices;
using UniversityACS.Application.Services.TeacherDisciplineServices;
using UniversityACS.Application.Services.TeacherTestServices;
using UniversityACS.Application.Services.TeachingLoadServices;
using UniversityACS.Application.Services.TraineeshipServices;
using UniversityACS.Application.Services.WorkingCurriculumServices;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationUserService, ApplicationUserService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDisciplineService, DisciplineService>();
        services.AddScoped<IScientificAndPedagogicalActivityService, ScientificAndPedagogicalActivityService>();
        services.AddScoped<ISyllabusService, SyllabusService>();
        services.AddScoped<ITraineeshipService, TraineeshipService>();
        services.AddScoped<ICertificationReportService, CertificationReportService>();
        services.AddScoped<ICurriculumService, CurriculumService>();
        services.AddScoped<IDepartmentMeetingPlanService, DepartmentMeetingPlanService>();
        services.AddScoped<IDepartmentMeetingProtocolService, DepartmentMeetingProtocolService>();
        services.AddScoped<IDevelopmentPlanService, DevelopmentPlanService>();
        services.AddScoped<IExchangeVisitPlanService, ExchangeVisitPlanService>();
        services.AddScoped<IIndividualPlanService, IndividualPlanService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IStatementService, StatementService>();
        services.AddScoped<ISubmissionToCertificationThemesService, SubmissionToCertificationThemesService>();
        services.AddScoped<ISubmissionToTheCommitteeService, SubmissionToTheCommitteeService>();
        services.AddScoped<ISubmissionToTheHeadOfCommitteeService, SubmissionToTheHeadOfCommitteeService>();
        services.AddScoped<ITeacherDisciplineService, TeacherDisciplineService>();
        services.AddScoped<ITeacherTestService, TeacherTestService>();
        services.AddScoped<ITeachingLoadService, TeachingLoadService>();
        services.AddScoped<IWorkingCurriculumService, WorkingCurriculumService>();
        services.AddScoped<IHomeWorkService, HomeWorkService>();
        services.AddScoped<IStudentsGroupService, StudentsGroupService>();
        services.AddScoped<IStudentAttendanceService, StudentAttendanceService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IStudentExamService, StudentExamService>();
        services.AddScoped<IExchangeVisitsPlanReviewService, ExchangeVisitsPlanReviewService>();

        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<TokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"])),
                ClockSkew = TimeSpan.Zero
            });

        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}