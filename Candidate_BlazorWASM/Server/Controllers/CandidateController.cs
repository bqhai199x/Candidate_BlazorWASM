using Candidate_BlazorWASM.Server.Repositories;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Controllers
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
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidate()
        {
            try
            {
                return Ok(await _candidateRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
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
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            try
            {
                if (candidate == null)
                    return BadRequest();

                var createdCandidate = await _candidateRepository.Create(candidate);

                return CreatedAtAction(nameof(GetCandidate),
                    new { id = createdCandidate.CandidateId }, createdCandidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new candidate record");
            }
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
