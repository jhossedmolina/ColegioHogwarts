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

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            var candidates = await _context.Candidates.ToListAsync();
            return candidates;
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Identification == id);
            return candidate;
        }

        public async Task InsertCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
