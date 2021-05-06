using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Pages
{
    public partial class Index
    {
        [Inject]
        ICandidateService candidateService { get; set; }

        [Inject]
        IPositionService positionService { get; set; }

        [Inject]
        ILevelService levelService { get; set; }

        private string searchStr { get; set; }

        private Candidate candi = new();

        private List<Level> lstLevel = new();

        private List<Position> lstPosition = new();

        private List<Candidate> lstCandi = new();

        protected override async Task OnInitializedAsync()
        {
            lstCandi = (await candidateService.GetAll()).ToList();
            lstLevel = (await levelService.GetAll()).ToList();
            lstPosition = (await positionService.GetAll()).ToList();

        }

        protected async Task ShowModal(int id)
        {
            candi = new();
            if (id != 0)
            {
                candi = await candidateService.GetById(id);
            }
        }

        protected async Task ShowCV(int id)
        {
            candi = await candidateService.GetById(id);
        }


        protected async Task Delete(int id)
        {
            await candidateService.Delete(id);
        }

        

        protected async Task PutPost()
        {
            if (candi.CandidateId == 0)
            {
                await candidateService.Create(candi);
            }
            else
            {
                await candidateService.Update(candi);
            }
        }

        protected async Task Search(string searchStr)
        {
            lstCandi = (await candidateService.GetAll()).ToList();
            if (!string.IsNullOrWhiteSpace(searchStr))
                lstCandi = candidateService.Search(lstCandi, searchStr).ToList();
        }
    }
}
