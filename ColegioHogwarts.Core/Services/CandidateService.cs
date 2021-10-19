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
        private readonly IHouseValidator _houseRepository;

        public CandidateService(IUnitOfWork unitOfWork, IHouseValidator houseValidator)
        {
            _unitOfWork = unitOfWork;
            _houseRepository = houseValidator;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _unitOfWork.CandidateRepository.GetAll();
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            return await _unitOfWork.CandidateRepository.GetById(id);
        }

        public async Task InsertCandidate(Candidate candidate)
        {
            if(!_houseRepository.HouseExist(candidate.House))
            {
                throw new GlobalException($"La casa {candidate.House} no existe. " +
                    $"Solo puede ingresar: Gryffindor, Slytherin, Hufflepuff o Ravenclaw");
            }
            await _unitOfWork.CandidateRepository.Add(candidate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            var existingCandidate = await _unitOfWork.CandidateRepository.GetById(candidate.Id);
            existingCandidate.Identification = candidate.Identification;
            existingCandidate.Name = candidate.Name;
            existingCandidate.LastName = candidate.LastName;
            existingCandidate.House = candidate.House;
            
            if (!_houseRepository.HouseExist(candidate.House))
            {
                throw new GlobalException($"La casa {candidate.House} no existe. " +
                    $"Solo puede ingresar: Gryffindor, Slytherin, Hufflepuff o Ravenclaw");
            }

            _unitOfWork.CandidateRepository.Update(existingCandidate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            await _unitOfWork.CandidateRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
