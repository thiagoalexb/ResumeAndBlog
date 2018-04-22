﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.Configurations.Config;
using Resume.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>, IConfiguring
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.DateOfBirth)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();

            builder.Property(c => c.Deleted);
        }
    }
}
