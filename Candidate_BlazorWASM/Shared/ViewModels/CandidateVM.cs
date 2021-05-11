using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Shared.ViewModels
{
    public class CandidateVM
    {
        public int CandidateId { get; set; }

        public int? PositionId { get; set; }

        public string PositionName { get; set; }

        public int? LevelId { get; set; }

        public string LevelName { get; set; }

        public string FullName { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string IntroduceName { get; set; }

        public string CVPath { get; set; }

        public bool IsApplied { get; set; }

        public int Status { get; set; }

        public int InterContacted { get; set; }

        public DateTime? InterTime { get; set; }

        public string InterLocation { get; set; }

        public string InterNote { get; set; }

        public string MailTitle { get; set; }

        public string MailBody { get; set; }
    }
}
