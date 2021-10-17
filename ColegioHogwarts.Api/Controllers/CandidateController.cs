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
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates(int? identification, string name, string lastName, int? age, string house)
        {
            var candidates = await _candidateService.GetCandidates();
            var candidatesDtos = _mapper.Map<IEnumerable<CandidateDto>>(candidates);
            var response = new ApiResponse<IEnumerable<CandidateDto>>(candidatesDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidate(id);
            var candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidate(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);

            await _candidateService.InsertCandidate(candidate);
            candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);          
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            candidate.IdCandidate = id;

            var result = await _candidateService.UpdateCandidate(candidate);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var result = await _candidateService.DeleteCandidate(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
