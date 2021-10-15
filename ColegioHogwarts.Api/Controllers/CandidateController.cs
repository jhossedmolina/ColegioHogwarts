using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ColegioHogwarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidate()
        {
            var candidate = await _candidateRepository.GetCandidate();
            return Ok(candidate);
        }
    }
}
