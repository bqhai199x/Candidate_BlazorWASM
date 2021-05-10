using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Components
{
    public partial class ShowCVModal
    {
        public bool Display { get; set; }

        private Candidate candi { get; set; } = new();

        private string CVPath { get; set; }       

        [Inject]
        ICandidateService candidateService { get; set; }

        public void Hide()
        {
            Display = false;
            StateHasChanged();
        }

        public async Task Show(int id)
        {
            if (id == 0)
            {
                candi = new();
            }
            else
            {
                candi = await candidateService.GetById(id);
                CVPath = $"/StaticFiles/CV/{candi.CVPath}";
            }
            Display = true;
            StateHasChanged();
        }
    }
}
