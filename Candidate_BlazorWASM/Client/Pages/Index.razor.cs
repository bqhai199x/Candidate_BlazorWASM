using Candidate_BlazorWASM.Client.Components;
using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Candidate_BlazorWASM.Shared.ViewModels;
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

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        private List<CandidateVM> lstCandi = new();

        public MetaData MetaData { get; set; } = new MetaData();

        private Parameters parameters = new Parameters();

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
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
        public async Task GetCandidates()
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

        public ShowCVModal CVModal { get; set; }

        public AddEditModal InfoModal { get; set; }

        protected async Task ShowCV(int id)
        {
            await CVModal.Show(id);
        }

        protected async Task ShowInfo(int id)
        {
            await InfoModal.Show(id);
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
