using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate> GetById(int candidateId);
        Task<Candidate> Create(Candidate candidate);
        Task<Candidate> Update(Candidate candidate);
        Task<Candidate> Delete(int candidateId);
    }
}