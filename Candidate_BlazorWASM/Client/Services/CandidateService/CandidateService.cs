using Candidate_BlazorWASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly HttpClient _httpClient;

        public CandidateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<Candidate[]>("api/candidate");
        }

        public async Task<Candidate> GetById(int candidateId)
        {
            return await _httpClient.GetFromJsonAsync<Candidate>($"api/candidate/{candidateId}");
        }

        public async Task Update(Candidate candidate)
        {
            await _httpClient.PutAsJsonAsync($"/api/candidate", candidate);
        }

        public async Task Create(Candidate candidate)
        {
            await _httpClient.PostAsJsonAsync("/api/candidate/", candidate);
        }

        public async Task Delete(int candidateId)
        {
            await _httpClient.DeleteAsync($"/api/candidate/{candidateId}");
        }

        public IEnumerable<Candidate> Search(IEnumerable<Candidate> candidate, string searchStr)
        {
            return candidate.Where(x => x.FullName.ToLower().Contains(searchStr.ToLower()));
        }

        public async Task<IEnumerable<Candidate>> GetByStatus(int status)
        {
            var result = await GetAll();
            return result.Where(x => x.Status == status);
        }

        public async Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2)
        {
            var result = await GetAll();
            return result.Where(x => x.Status == status1 || x.Status == status2);
        }

        public IEnumerable<Candidate> GetWithFiltering(IEnumerable<Candidate> candidate, int positionId, int levelId)
        {
            if(positionId != 0)
            {
                candidate = candidate.Where(x => x.PositionId == positionId);
            }
            if (levelId != 0)
            {
                candidate = candidate.Where(x => x.LevelId == levelId);
            }
            return candidate;
        }

        public IEnumerable<Candidate> GetWithFiltering(IEnumerable<Candidate> candidate, int positionId, int levelId, int? isContacted, DateTime? fromDate, DateTime? toDate, string location)
        {
            if (positionId != 0)
            {
                candidate = candidate.Where(x => x.PositionId == positionId);
            }
            if (levelId != 0)
            {
                candidate = candidate.Where(x => x.LevelId == levelId);
            }
            if (isContacted != null)
            {
                candidate = candidate.Where(x => x.InterContacted == isContacted);
            }
            if (fromDate != null)
            {
                candidate = candidate.Where(x => x.InterTime > fromDate);
            }
            if (toDate != null)
            {
                candidate = candidate.Where(x => x.InterTime < toDate);
            }
            if (!string.IsNullOrEmpty(location))
            {
                candidate = candidate.Where(x => x.InterLocation == location);
            }
            return candidate;
        }
    }
}
