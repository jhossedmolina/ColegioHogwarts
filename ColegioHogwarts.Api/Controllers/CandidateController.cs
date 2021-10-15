using AutoMapper;
using ColegioHogwarts.Core.DTOs;
using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioHogwarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _candidateRepository.GetCandidates();
            var candidatesDtos = _mapper.Map<IEnumerable<CandidateDto>>(candidates);

            return Ok(candidatesDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _candidateRepository.GetCandidate(id);
            var candidatesDtos = _mapper.Map<CandidateDto>(candidate);

            return Ok(candidatesDtos);
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidate(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);

            await _candidateRepository.InsertCandidate(candidate);
            return Ok(candidate);
        }
    }
}
