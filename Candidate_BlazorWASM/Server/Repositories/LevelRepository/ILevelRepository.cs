using Candidate_BlazorWASM.Shared;
using System.Collections.Generic;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public interface ILevelRepository
    {
        IEnumerable<Level> GetAll();
    }
}