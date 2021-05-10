using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Candidate_BlazorWASM.Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Components
{
    public partial class AddEditModal
    {
        [Inject]
        IPositionService positionService { get; set; }

        [Inject]
        ILevelService levelService { get; set; }

        [Inject]
        ICandidateService candidateService { get; set; }

        private Candidate candi { get; set; } = new();

        private List<Level> lstLevel = new();

        private List<Position> lstPosition = new();

        public bool Display { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lstLevel = (await levelService.GetAll()).ToList();
            lstPosition = (await positionService.GetAll()).ToList();
        }

        public async Task Show(int id)
        {
            candi = new();
            if (id != 0)
            {
                candi = await candidateService.GetById(id);
            }
            Display = true;
            StateHasChanged();
        }

        private void Hide()
        {        
            Display = false;
            StateHasChanged();
        }

        IBrowserFile selectedFiles;

        protected void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.File;
            StateHasChanged();
        }

        private async Task Save()
        {
            if (selectedFiles != null)
            {
                Stream stream = selectedFiles.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                stream.Close();

                UploadedFile file = new UploadedFile();
                file.FileName = selectedFiles.Name;
                file.FileContent = ms.ToArray();
                ms.Close();

                await candidateService.UploadCV(file);

                candi.CVPath = file.FileName;
                selectedFiles = null;
            }

            if (candi.CandidateId == 0)
            {
                await candidateService.Create(candi);
            }
            else
            {
                await candidateService.Update(candi);
            }
            await OnClose.InvokeAsync();
            Hide();
        }
    }
}
