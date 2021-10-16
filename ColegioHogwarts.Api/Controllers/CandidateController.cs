using AutoMapper;
using ColegioHogwarts.Api.Responses;
using ColegioHogwarts.Core.DTOs;
using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColegioHogwarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;
        private readonly IHouseValidator _houseValidator;

        public CandidateController(ICandidateRepository candidateRepository, IMapper mapper, IHouseValidator houseValidator)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _houseValidator = houseValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _candidateRepository.GetCandidates();
            var candidatesDtos = _mapper.Map<IEnumerable<CandidateDto>>(candidates);
            var response = new ApiResponse<IEnumerable<CandidateDto>>(candidatesDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _candidateRepository.GetCandidate(id);
            var candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidate(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);

            if (!_houseValidator.HouseExist(candidateDto.House))
                return BadRequest($"La casa {candidateDto.House} no existe");

            await _candidateRepository.InsertCandidate(candidate);
            candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);          
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            candidate.IdCandidate = id;
            
            if (!_houseValidator.HouseExist(candidateDto.House))
                return BadRequest($"La casa {candidateDto.House} no existe");

            var result = await _candidateRepository.UpdateCandidate(candidate);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var result = await _candidateRepository.DeleteCandidate(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
