﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Mappings
{
    public class CoachMapping : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable("Coaches", schema: "Core");

            builder.HasKey(c => c.Id)
                .ForSqlServerIsClustered(false);

            builder.Property(c => c.Id)
                .ValueGeneratedNever();

            builder.HasAlternateKey(c => c.Login);

            builder.HasMany(c => c.Runners)
                .WithOne(r => r.Coach)
                .HasForeignKey("CoachId");

            builder.OwnsOne<Email>(c => c.Email)
                .Property(x => x.EmailAdress)
                .HasColumnName("Email")
                .IsRequired();
        }
    }
}
