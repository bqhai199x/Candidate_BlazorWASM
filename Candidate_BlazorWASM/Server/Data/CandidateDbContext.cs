using Candidate_BlazorWASM.Server.Configuration;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Candidate_BlazorWASM.Server.Data
{
    public class CandidateDbContext : IdentityDbContext<User>
    {
        public CandidateDbContext (DbContextOptions<CandidateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
