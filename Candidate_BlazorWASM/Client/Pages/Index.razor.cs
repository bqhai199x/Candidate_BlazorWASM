using Candidate_BlazorWASM.Client.Components;
using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        public IJSRuntime Js { get; set; }

        private List<Candidate> lstCandi = new();

        public MetaData MetaData { get; set; } = new MetaData();

        private Parameters parameters = new Parameters();

        protected override async Task OnParametersSetAsync()
        {
            await GetCandidates();
        }
        protected async Task SearchChanged(string searchTerm)
        {
            parameters.PageNumber = 1;
            parameters.SearchTerm = searchTerm;
            await GetCandidates();
        }

        protected async Task SelectedPage(int page)
        {
            parameters.PageNumber = page;
            await GetCandidates();
        }
        protected async Task GetCandidates()
        {
            var pagingResponse = await candidateService.GetAll(parameters);
            lstCandi = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        protected async Task SortChanged(string orderBy)
        {
            parameters.OrderBy = orderBy;
            await GetCandidates();
        }

        //Show Modal Add Edit
        public int CandiId { get; set; }
        public bool Display { get; set; }
        protected void ShowInfo(int candiId)
        {
            Display = true;
            CandiId = candiId;
            StateHasChanged();
        }

        protected async Task OnClose()
        {
            await GetCandidates();
            Display = false;
        }

        protected async Task Delete(int candiId)
        {
            var candiName = lstCandi.FirstOrDefault(x => x.CandidateId == candiId);
            var confirmed = await Js.InvokeAsync<bool>("confirm", $" Bạn có chắc muốn xoá ứng viên {candiName.FullName}?");
            if (confirmed)
            {
                await candidateService.Delete(candiId);
                await GetCandidates();
            }
        }
    }
}
