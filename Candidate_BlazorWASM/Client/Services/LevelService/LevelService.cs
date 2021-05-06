using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    public class LevelService : ILevelService
    {
        private readonly HttpClient _httpClient;

        public LevelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Level>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Level>>("api/level");
        }
    }
}
