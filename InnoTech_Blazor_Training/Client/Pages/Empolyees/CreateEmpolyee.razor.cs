namespace InnoTech_Blazor_Training.Client.Pages.Empolyees
{
    public partial class CreateEmpolyee
    {
        [Parameter] public Empolyee? Empolyee { get; set; }
        [Inject] public HttpClient _httpClient { get; set; }
        [Inject] public AppObserver _appObserver { get; set; }
        private ModelForm model { get; set; }

        Empolyee empolyee = new();
        private string url = "api/empolyee";
        private string formId = "AddEmpolyee";
        private async Task Create()
        {
            await _httpClient.PostAsJsonAsync(url, empolyee);
            empolyee = new();
            _appObserver.EmpolyeeHasChanged();

            model.Close();
        }

    }
}
