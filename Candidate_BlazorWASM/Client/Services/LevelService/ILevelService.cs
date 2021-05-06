using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    interface ILevelService
    {
        Task<IEnumerable<Level>> GetAll();
    }
}
