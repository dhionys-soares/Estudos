﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity
{
    public class IdentityUserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<long>> builder)
        {
            builder.ToTable("IdentityUserToken");
            builder.HasKey(t => new {t.UserId, t.LoginProvider, t.Name});

            builder.Property(lp => lp.LoginProvider).HasMaxLength(120);
            builder.Property(n => n.Name).HasMaxLength(180);
        }
    }
}