using Candidate_BlazorWASM.Server.Repositories;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Candidate_BlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // GET: api/Level
        [HttpGet]
        public ActionResult<IEnumerable<Position>> GetLevel()
        {
            try
            {
                return Ok(_positionRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
