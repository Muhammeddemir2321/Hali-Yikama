﻿using Hali.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hali.Repository.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Company).WithMany(x => x.Users).HasForeignKey(x => x.CompanyId).IsRequired();
        }
    }
}
