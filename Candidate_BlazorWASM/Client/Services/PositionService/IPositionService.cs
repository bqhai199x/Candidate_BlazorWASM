using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    interface IPositionService
    {
        Task<IEnumerable<Position>> GetAll();
    }
}
