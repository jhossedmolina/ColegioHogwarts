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
        private IUnitOfWork _unitOfWork;
        private readonly IHouseRepository _houseRepository;

        public CandidateService(IUnitOfWork unitOfWork, IHouseRepository houseValidator)
        {
            _unitOfWork = unitOfWork;
            _houseRepository = houseValidator;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _unitOfWork.CandidateRepository.GetAll();
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            return await _unitOfWork.CandidateRepository.GetById(id);
        }

        public async Task InsertCandidate(Candidate candidate)
        {
            if(!_houseRepository.HouseExist(candidate.House))
            {
                throw new CandidateException($"La casa {candidate.House} no existe");
            }
            await _unitOfWork.CandidateRepository.Add(candidate);
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            if(!_houseRepository.HouseExist(candidate.House))
            {
                throw new CandidateException($"La casa {candidate.House} no existe. " +
                    $"Solo puede ingresar: Gryffindor, Slytherin, Hufflepuff o Ravenclaw");
            }

            await _unitOfWork.CandidateRepository.Update(candidate);
            return true;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            await _unitOfWork.CandidateRepository.Delete(id);
            return true;
        }
    }
}
