using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioHogwarts.Infraestructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ColegioHogwartsDBContext _context;
        public CandidateRepository(ColegioHogwartsDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidate()
        {
            var candidate = await _context.Candidates.ToListAsync();
            return candidate;
        }
    }
}
