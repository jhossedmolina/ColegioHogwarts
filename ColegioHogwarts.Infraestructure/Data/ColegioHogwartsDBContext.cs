using ColegioHogwarts.Core.Entities;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual DbSet<Aspirante> Aspirante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspirante>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Casa)
                    .IsRequired()
                    .HasColumnName("casa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
