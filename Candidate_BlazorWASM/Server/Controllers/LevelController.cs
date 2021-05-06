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
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepository _levelRepository;

        public LevelController(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        // GET: api/Level
        [HttpGet]
        public ActionResult<IEnumerable<Level>> GetLevel()
        {
            try
            {
                return Ok( _levelRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
