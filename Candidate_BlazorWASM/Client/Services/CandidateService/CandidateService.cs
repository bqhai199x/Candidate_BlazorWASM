using Candidate_BlazorWASM.Client.Features;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Candidate_BlazorWASM.Shared.ViewModels;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task<PagingResponse<CandidateVM>> GetAll(Parameters parameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["searchTerm"] = parameters.SearchTerm == null ? "" : parameters.SearchTerm,
                ["orderBy"] = parameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/candidate", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<CandidateVM>
            {
                Items = JsonSerializer.Deserialize<List<CandidateVM>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };

            return pagingResponse;
        }

        public async Task<Candidate> GetById(int candidateId)
        {
            return await _httpClient.GetFromJsonAsync<Candidate>($"api/candidate/{candidateId}");
        }

        public async Task Update(Candidate candidate)
        {
            await _httpClient.PutAsJsonAsync("api/candidate", candidate);
        }

        public async Task Create(Candidate candidate)
        {
            await _httpClient.PostAsJsonAsync("api/candidate", candidate);
        }

        public async Task Delete(int candidateId)
        {
            await _httpClient.DeleteAsync($"/api/candidate/{candidateId}");
        }

        public async Task UploadCV(UploadedFile file)
        {
            await _httpClient.PostAsJsonAsync("api/upload", file);
        }
    }
}
