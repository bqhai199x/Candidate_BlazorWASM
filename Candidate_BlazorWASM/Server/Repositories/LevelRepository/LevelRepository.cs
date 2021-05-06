using Candidate_BlazorWASM.Server.Data;
using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly CandidateDbContext _context;

        public LevelRepository(CandidateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Level> GetAll()
        {
            return _context.Level;
        }
    }
}
