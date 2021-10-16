using System;
using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ColegioHogwarts.Infraestructure.Data
{
    public partial class ColegioHogwartsDBContext : DbContext
    {
        public ColegioHogwartsDBContext()
        {
        }

        public ColegioHogwartsDBContext(DbContextOptions<ColegioHogwartsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
