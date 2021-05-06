using Candidate_BlazorWASM.Client.Services;
using Candidate_BlazorWASM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Components
{
    public partial class SearchBox
    {
        [Parameter]
        public EventCallback<string> OnSearchSubmit { get; set; }

        public string searchStr { get; set; }

        private void SearchSubmit()
        {
            OnSearchSubmit.InvokeAsync(searchStr);
        }
    }
}
