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
            var candidates = await _context.Candidate.ToListAsync();
            return candidates;
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            var candidate = await _context.Candidate.FirstOrDefaultAsync(x => x.IdCandidate == id);
            return candidate;
        }

        public async Task InsertCandidate(Candidate candidate)
        {
            _context.Candidate.Add(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            var currentCandidate = await GetCandidate(candidate.IdCandidate);
            currentCandidate.Identification = candidate.Identification;
            currentCandidate.Name = candidate.Name;
            currentCandidate.LastName = candidate.LastName;
            currentCandidate.Age = candidate.Age;
            currentCandidate.House = candidate.House;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var currentCandidate = await GetCandidate(id);
            _context.Candidate.Remove(currentCandidate);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
