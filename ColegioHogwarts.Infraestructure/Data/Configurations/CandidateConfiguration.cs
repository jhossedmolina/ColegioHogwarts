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
            builder.HasKey(e => e.IdCandidate);

            builder.Property(e => e.IdCandidate).HasColumnName("idCandidate");

            builder.Property(e => e.Age).HasColumnName("age");

            builder.Property(e => e.House)
                .IsRequired()
                .HasColumnName("house")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Identification).HasColumnName("identification");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
