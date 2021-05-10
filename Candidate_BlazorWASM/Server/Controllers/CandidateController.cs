using Candidate_BlazorWASM.Server.Repositories;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameters parameters)
        {
            var candidates = await _candidateRepository.GetAll(parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(candidates.MetaData));
            return Ok(candidates);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            try
            {
                var result = await _candidateRepository.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Candidate>> PutCandidate(Candidate candidate)
        {
            try
            {
                var candidateToUpdate = await _candidateRepository.GetById(candidate.CandidateId);

                if (candidateToUpdate == null)
                    return NotFound($"Candidate with Id = {candidate.CandidateId} not found");

                return await _candidateRepository.Update(candidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidate(Candidate candidate)
        {
            if (candidate == null)
                return BadRequest();

            //model validation…
            await _candidateRepository.Create(candidate);
            return Created("", candidate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidate(int id)
        {
            try
            {
                var candidateToDelete = await _candidateRepository.GetById(id);

                if (candidateToDelete == null)
                {
                    return NotFound($"Candidate with Id = {id} not found");
                }

                return await _candidateRepository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
