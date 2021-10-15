using ColegioHogwarts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Infraestructure.Data.Configurations
{
    class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Aspirante");

            builder.HasKey(e => e.Identification);

            builder.Property(e => e.Identification)
                .HasColumnName("identificacion")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
               .IsRequired()
               .HasColumnName("nombre")
               .HasMaxLength(20)
               .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("apellido")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.House)
                .IsRequired()
                .HasColumnName("casaAspira")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Age).HasColumnName("edad");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
