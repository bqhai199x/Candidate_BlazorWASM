using Candidate_BlazorWASM.Server.Extensions;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Candidate_BlazorWASM.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public interface ICandidateRepository
    {
        Task<PagedList<CandidateVM>> GetAll(Parameters parameters);
        Task<Candidate> GetById(int candidateId);
        Task Create(Candidate candidate);
        Task<Candidate> Update(Candidate candidate);
        Task<Candidate> Delete(int candidateId);
    }
}