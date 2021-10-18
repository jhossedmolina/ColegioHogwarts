using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Data;
using System.Threading.Tasks;

namespace ColegioHogwarts.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ColegioHogwartsDBContext _context;
        private readonly IRepository<Candidate> _candidateRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(ColegioHogwartsDBContext context)
        {
            _context = context;
        }
        public IRepository<Candidate> CandidateRepository => _candidateRepository ?? new BaseRepository<Candidate>(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
           if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
