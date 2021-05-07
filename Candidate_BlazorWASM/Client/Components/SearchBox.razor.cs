using Microsoft.AspNetCore.Components;
using System.Threading;

namespace Candidate_BlazorWASM.Client.Components
{
    public partial class SearchBox
    {
        public string SearchTerm { get; set; }
        [Parameter]
        public EventCallback<string> OnSearchChanged { get; set; }

        private Timer _timer;

        private void SearchChanged()
        {
            if (_timer != null)
                _timer.Dispose();
            _timer = new Timer(OnTimerElapsed, null, 500, 0);
        }
        private void OnTimerElapsed(object sender)
        {
            OnSearchChanged.InvokeAsync(SearchTerm);
            _timer.Dispose();
        }
    }
}
