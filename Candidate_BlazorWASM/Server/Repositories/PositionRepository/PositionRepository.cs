using Candidate_BlazorWASM.Server.Data;
using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly CandidateDbContext _context;

        public PositionRepository(CandidateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Position> GetAll()
        {
            return _context.Position.ToList();
        }
    }
}
