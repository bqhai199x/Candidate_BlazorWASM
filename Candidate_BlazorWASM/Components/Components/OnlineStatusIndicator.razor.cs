using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Components.Components
{
    public partial class OnlineStatusIndicator
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var dotNetObjRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("onlineStatusIndicator.registerOnlineStatusHandler", dotNetObjRef);
            }
        }


        private string _color;

        [JSInvokable]
        public void SetOnlineStatusColor(bool isOnline)
        {
            _color = isOnline ? "green" : "red";
            StateHasChanged();
        }
    }
}
