using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Components
{
    public partial class SortBar
    {
        [Parameter]
        public EventCallback<string> OnSortChanged { get; set; }
        private async Task ApplySort(ChangeEventArgs eventArgs)
        {
            if (eventArgs.Value.ToString() == "-1")
                return;
            await OnSortChanged.InvokeAsync(eventArgs.Value.ToString());
        }
    }
}
