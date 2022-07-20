namespace InnoTech_Blazor_Training.Client.Pages.Empolyees
{
    public partial class Empolyees
    {
        [Inject] public HttpClient? _httpClient { get; set; }
        [Inject] public AppObserver _appObserver { get; set; }
        public string SearchTerm { get; set; } = string.Empty;

        private List<Empolyee>? empolyees;

        private string url = "api/empolyee";

        private List<Empolyee> FilteredEmpolyees => (empolyees ?? new
                List<Empolyee>()).Where(e => e.Name != null && e.Name.ToLower().Contains(SearchTerm.ToLower())).ToList();

        protected override async Task OnInitializedAsync()
        {
            _appObserver.OnEmpolyeeChanged += InvokeStateHasChange();
            await LoadEmpolyees();
        }

        public Action InvokeStateHasChange() => (() =>
        {
            Task.Run(async () =>
            {
                await LoadEmpolyees();
                StateHasChanged();
            });

        });

        private async Task LoadEmpolyees() => empolyees = await _httpClient.GetFromJsonAsync<List<Empolyee>>(url);

        private void Clear() => SearchTerm = string.Empty;

        private async Task DeleteEmpolyee(Guid? id)
        {
            var deleteUrl = $"{url}/{id}";
            await _httpClient.DeleteAsync(deleteUrl);
            empolyees = await _httpClient.GetFromJsonAsync<List<Empolyee>>(url);
        }

        public void Dispose() => _appObserver.OnEmpolyeeChanged -= InvokeStateHasChange();
    }
}
