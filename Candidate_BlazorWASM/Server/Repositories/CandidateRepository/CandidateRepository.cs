using Candidate_BlazorWASM.Server.Data;
using Candidate_BlazorWASM.Server.Extensions;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Candidate_BlazorWASM.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public CandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<CandidateVM>> GetAll(Parameters parameters)
        {
            var candidates = await (
                from c in _context.Candidate
                join p in _context.Position on c.PositionId equals p.PositionId
                join l in _context.Level on c.LevelId equals l.LevelId
                select new CandidateVM
                {
                    CandidateId = c.CandidateId,
                    PositionId = p.PositionId,
                    PositionName = p.PositionName,
                    LevelId = c.LevelId,
                    LevelName = l.LevelName,
                    FullName = c.FullName,
                    Birthday = c.Birthday,
                    Address = c.Address,
                    IntroduceName = c.IntroduceName,
                    Email = c.Email,
                    CVPath = c.CVPath,
                    Phone = c.Phone,
                    Status = c.Status
                })
                .Search(parameters.SearchTerm)
                .Sort(parameters.OrderBy)
                .ToListAsync();

            return PagedList<CandidateVM>
                .ToPagedList(candidates, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Candidate> GetById(int candidateId)
        {
            return await _context.Candidate
                .FirstOrDefaultAsync(x => x.CandidateId == candidateId);
        }

        public async Task Create(Candidate candidate)
        {
            _context.Add(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate> Update(Candidate candidate)
        {
            var result = await _context.Candidate
                .FirstOrDefaultAsync(c => c.CandidateId == candidate.CandidateId);

            if (result != null)
            {
                result.PositionId = candidate.PositionId;
                result.LevelId = candidate.LevelId;
                result.FullName = candidate.FullName;
                result.Birthday = candidate.Birthday;
                result.Address = candidate.Address;
                result.Address = candidate.Address;
                result.Email = candidate.Email;
                result.Phone = candidate.Phone;
                result.CVPath = candidate.CVPath;
                result.IntroduceName = candidate.IntroduceName;
                result.IsApplied = candidate.IsApplied;
                result.Status = candidate.Status;
                result.InterContacted = candidate.InterContacted;
                result.InterTime = candidate.InterTime;
                result.InterLocation = candidate.InterLocation;
                result.InterNote = candidate.InterNote;
                result.MailTitle = candidate.MailTitle;
                result.MailBody = candidate.MailBody;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Candidate> Delete(int candidateId)
        {
            var result = await _context.Candidate.FindAsync(candidateId);
            if (result != null)
            {
                _context.Candidate.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }


    }
}
