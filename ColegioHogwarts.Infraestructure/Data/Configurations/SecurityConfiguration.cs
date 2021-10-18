using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Infraestructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
                /*builder.HasKey(e => e.IdSecurity)
                    .HasName("PK__Security__77863C70D73D33D1");*/

                builder.Property(e => e.PasswordUser)
                            .IsRequired()
                            .HasMaxLength(200)
                            .IsUnicode(false);

                builder.Property(e => e.RoleUser)
                            .IsRequired()
                            .HasMaxLength(15)
                            .HasConversion(
                            x => x.ToString(),
                            x => (RoleType)Enum.Parse(typeof(RoleType), x)
                            )
                            .IsUnicode(false);

                builder.Property(e => e.UserName)
                            .IsRequired()
                            .HasMaxLength(100)
                            .IsUnicode(false);

                builder.Property(e => e.UserSecurity)
                            .IsRequired()
                            .HasMaxLength(50)
                            .IsUnicode(false);
        }
    }
}
