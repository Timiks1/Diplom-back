using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext.FluentConfigurations;

namespace UniversityACS.Data.DataContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<IdentityUserRole<Guid>> IdentityUserRoles { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<ScientificAndPedagogicalActivity> ScientificAndPedagogicalActivities { get; set; }
    public DbSet<Syllabus> Syllabi { get; set; }
    public DbSet<Traineeship> Traineeships { get; set; }
    public DbSet<CertificationReport> CertificationReports { get; set; }
    public DbSet<Curriculum> Curricula { get; set; }
    public DbSet<DepartmentMeetingPlan> DepartmentMeetingPlans { get; set; }
    public DbSet<DevelopmentPlan> DevelopmentPlans { get; set; }
    public DbSet<ExchangeVisitsPlan> ExchangeVisitsPlans { get; set; }
    public DbSet<IndividualPlan> IndividualPlans { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<DepartmentMeetingProtocol> DepartmentMeetingProtocols { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Statement> Statements { get; set; }
    public DbSet<SubmissionToCertificationThemes> SubmissionToCertificationThemes { get; set; }
    public DbSet<SubmissionToTheCommittee> SubmissionToTheCommittees { get; set; }
    public DbSet<SubmissionToTheHeadOfCommittee> SubmissionToTheHeadOfCommittees { get; set; }
    public DbSet<TeacherTest> TeacherTests { get; set; }
    public DbSet<TeachingLoad> TeachingLoads { get; set; }
    public DbSet<WorkingCurriculum> WorkingCurricula { get; set; }
    public DbSet<TeacherDiscipline> TeacherDisciplines { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<StudentsGroup> StudentsGroups { get; set; }
    public DbSet<HomeWork> HomeWorks { get; set; }
    public DbSet<StudentAttendance> StudentAttendances { get; set; }
    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<StudentExam> StudentExams { get; set; }

    public DbSet<ExchangeVisitsPlanReviews> ExchangeVisitsPlanReviews { get; set; }
}