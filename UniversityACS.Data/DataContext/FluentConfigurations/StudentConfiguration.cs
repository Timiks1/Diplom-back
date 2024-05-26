﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace UniversityACS.Data.DataContext.FluentConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(s => s.Homeworks)
            .WithOne()
            .HasForeignKey(h => h.Id);
            builder
            .HasMany(s => s.Reviews)
            .WithOne()
            .HasForeignKey(r => r.StudentId);
        }
    }
}
