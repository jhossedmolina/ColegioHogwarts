using ColegioHogwarts.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetCandidates();

        Task<Candidate> GetCandidate(int id);

        Task InsertCandidate(Candidate candidate);

        Task<bool> UpdateCandidate(Candidate candidate);

        Task<bool> DeleteCandidate(int id);
    }
}