using AutoMapper;
using ColegioHogwarts.Api.Responses;
using ColegioHogwarts.Core.DTOs;
using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ColegioHogwarts.Api.Controllers
{
    [Authorize]
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


        /// <summary>
        /// Consulta todas las solicitudes enviadas por los aspirantes
        /// </summary>
        /// <returns></returns>
        
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CandidateDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        public IActionResult GetCandidates()
        {
            var candidates = _candidateService.GetCandidates();
            var candidatesDtos = _mapper.Map<IEnumerable<CandidateDto>>(candidates);
            var response = new ApiResponse<IEnumerable<CandidateDto>>(candidatesDtos);
            return Ok(response);
        }

        /// <summary>
        /// Consulta por id la solicitud enviada por los aspirantes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidate(id);
            var candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);
            return Ok(response);
        }

        /// <summary>
        /// Crea una nueva solicitud de ingreso. El campo id del Request Body debe eliminarse o dejarse ya que es autoincremental y en el campo house del Request Body solo se puede ingresar: Gryffindor, Ravenclaw, Slytherin o Hufflepuff
        /// </summary>
        /// <param name="candidateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCandidate(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);

            await _candidateService.InsertCandidate(candidate);
            candidateDto = _mapper.Map<CandidateDto>(candidate);
            var response = new ApiResponse<CandidateDto>(candidateDto);          
            return Ok(response);
        }

        /// <summary>
        /// Actualiza una solicitud de ingreso. El campo id del Request Body debe eliminarse o dejarse en 0 ya que es autoincremental y en el campo house del Request Body solo se puede ingresar: Gryffindor, Ravenclaw, Slytherin o Hufflepuff
        /// </summary>
        /// <param name="id"></param>
        /// <param name="candidateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            candidate.Id = id;

            var result = await _candidateService.UpdateCandidate(candidate);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Elimina una solicitud de ingreso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var result = await _candidateService.DeleteCandidate(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
