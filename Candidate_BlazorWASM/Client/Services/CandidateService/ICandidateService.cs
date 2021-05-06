using Candidate_BlazorWASM.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAll();

        Task<Candidate> GetById(int candidateId);

        Task Create(Candidate candidate);

        Task Update(Candidate candidate);

        Task Delete(int candidateId);

        IEnumerable<Candidate> Search(IEnumerable<Candidate> candidate, string searchStr);

        Task<IEnumerable<Candidate>> GetByStatus(int status);

        Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2);

        IEnumerable<Candidate> GetWithFiltering(IEnumerable<Candidate> candidate, int positionId, int levelId);

        IEnumerable<Candidate> GetWithFiltering(IEnumerable<Candidate> candidate, int positionId, int levelId, int? isContacted, DateTime? fromDate, DateTime? toDate, string location);
    }
}
