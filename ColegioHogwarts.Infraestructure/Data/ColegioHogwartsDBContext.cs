using ColegioHogwarts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public virtual DbSet<Security> Security { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
