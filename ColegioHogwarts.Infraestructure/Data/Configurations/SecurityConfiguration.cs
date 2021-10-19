using ColegioHogwarts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColegioHogwarts.Infraestructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("IdSecurity");

            builder.Property(e => e.PasswordUser)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.RoleUser)
                .IsRequired()
                .HasMaxLength(15)
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
