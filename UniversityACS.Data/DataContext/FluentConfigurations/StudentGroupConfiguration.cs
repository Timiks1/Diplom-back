using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityACS.Core.Entities;

namespace UniversityACS.Data.DataContext.FluentConfigurations;

public class StudentsGroupConfiguration : IEntityTypeConfiguration<StudentsGroup>
{
    public void Configure(EntityTypeBuilder<StudentsGroup> builder)
    {
        builder.HasMany(sg => sg.Students)
               .WithMany(s => s.StudentsGroups)
               .UsingEntity(j => j.ToTable("StudentsGroupStudents"));

        builder.HasMany(sg => sg.Disciplines)
               .WithMany(d => d.StudentsGroups)
               .UsingEntity(j => j.ToTable("StudentsGroupDisciplines"));

        builder.Property(sg => sg.Name).IsRequired().HasMaxLength(100);
        builder.Property(sg => sg.Description).HasMaxLength(500);
    }
}
