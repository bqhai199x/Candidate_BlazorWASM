using Candidate_BlazorWASM.Client.Features;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    public interface ICandidateService
    {
        Task<PagingResponse<Candidate>> GetAll(Parameters parameters);

        Task<Candidate> GetById(int candidateId);

        Task Create(Candidate candidate);

        Task Update(Candidate candidate);

        Task Delete(int candidateId);

        Task UploadCV(UploadedFile file);
    }
}
