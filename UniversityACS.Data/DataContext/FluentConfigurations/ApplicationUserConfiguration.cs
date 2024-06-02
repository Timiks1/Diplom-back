using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityACS.Core.Entities;

namespace UniversityACS.Data.DataContext.FluentConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany(x => x.Disciplines)
            .WithMany(x => x.Teachers)
            .UsingEntity<TeacherDiscipline>();



        var hasher = new PasswordHasher<ApplicationUser>();

        var adminUser = new ApplicationUser()
        {
            Id = new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            LockoutEnabled = false,
            SecurityStamp = ""
        };

        adminUser.PasswordHash = hasher.HashPassword(adminUser, "123");

        builder.HasData(adminUser);
    }
}