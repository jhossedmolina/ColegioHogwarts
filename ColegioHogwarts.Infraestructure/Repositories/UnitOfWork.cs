using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColegioHogwarts.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ColegioHogwartsDBContext _context;
        private readonly IRepository<Candidate> _candidateRepository;

        public UnitOfWork(ColegioHogwartsDBContext context)
        {
            _context = context;
        }
        public IRepository<Candidate> CandidateRepository => _candidateRepository ?? new BaseRepository<Candidate>(_context);

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
