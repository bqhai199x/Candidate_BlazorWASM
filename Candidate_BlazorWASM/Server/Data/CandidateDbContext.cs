using Candidate_BlazorWASM.Shared;
using Microsoft.EntityFrameworkCore;

namespace Candidate_BlazorWASM.Server.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext (DbContextOptions<CandidateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
