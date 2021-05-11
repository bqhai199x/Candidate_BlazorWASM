using Candidae_Blazor.Toastr;
using Candidae_Blazor.Toastr.Enumerations;
using Candidae_Blazor.Toastr.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Pages.JSInterop
{
    public partial class WrappingJsLibraryInDotNet
    {
        [Inject]
        public ToastrService ToastrService { get; set; }
        private async Task ShowToastrInfo()
        {
            var message = "This is a message sent from the C# method";
            var options = new ToastrOptions
            {
                CloseButton = true,
                HideDuration = 300,
                HideMethod = ToastrHideMethod.SlideUp,
                ShowMethod = ToastrShowMethod.SlideDown,
                Position = ToastrPosition.BottomRight
            };
            await ToastrService.ShowInfoMessage(message, options);
        }
    }
}
