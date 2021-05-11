using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Pages.JSInterop
{
    public partial class CallDotNetFromJavaScript
    {
        [JSInvokable]
        public static string CalculateSquareRoot(int number)
        {
            var result = Math.Sqrt(number);
            return $"The square root of {number} is {result}";
        }

        [JSInvokable("CalculateSquareRootWithJustResult")]
        public static string CalculateSquareRoot(int number, bool justResult)
        {
            var result = Math.Sqrt(number);
            return !justResult ?
                $"The square root of {number} is {result}" :
                result.ToString();
        }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private async Task SendDotNetInstanceToJS()
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            //await JSRuntime.InvokeVoidAsync("jsFunctions.showMouseCoordinates", dotNetObjRef);
            await JSRuntime.InvokeVoidAsync("jsFunctions.registerMouseCoordinatesHandler", dotNetObjRef);
        }

        private MouseCoordinates _coordinates = new MouseCoordinates();

        [JSInvokable]
        public void ShowCoordinates(MouseCoordinates coordinates)
        {
            _coordinates = coordinates;
            StateHasChanged();
        }

    }
}
