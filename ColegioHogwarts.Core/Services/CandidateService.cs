using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Exceptions;
using ColegioHogwarts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IHouseRepository _houseValidator;

        public CandidateService(ICandidateRepository candidateRepository, IHouseRepository houseValidator)
        {
            _candidateRepository = candidateRepository;
            _houseValidator = houseValidator;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _candidateRepository.GetCandidates();
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            return await _candidateRepository.GetCandidate(id);
        }

        public async Task InsertCandidate(Candidate candidate)
        {
            if(!_houseValidator.HouseExist(candidate.House))
            {
                throw new CandidateException($"La casa {candidate.House} no existe");
            }
            await _candidateRepository.InsertCandidate(candidate);
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            if (!_houseValidator.HouseExist(candidate.House))
            {
                throw new CandidateException($"La casa {candidate.House} no existe. " +
                    $"Solo puede ingresar: Gryffindor, Slytherin, Hufflepuff o Ravenclaw");
            }
            return await _candidateRepository.UpdateCandidate(candidate);
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            return await _candidateRepository.DeleteCandidate(id);
        }
    }
}
