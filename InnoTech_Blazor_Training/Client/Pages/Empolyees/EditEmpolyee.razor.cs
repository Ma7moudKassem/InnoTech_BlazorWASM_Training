namespace InnoTech_Blazor_Training.Client.Pages.Empolyees
{
    public partial class EditEmpolyee
    {
        [Parameter] public Empolyee? Empolyee { get; set; }
        [Inject] public HttpClient _httpClient { get; set; }
        [Inject] public AppObserver _appObserver { get; set; }
        private ModelForm model { get; set; }

        private string url = "api/empolyee";
        private string formId = $"EditEmpolyee{Guid.NewGuid().ToString()}";
        private async Task Edit()
        {
            await _httpClient.PutAsJsonAsync($"{url}", Empolyee);
            _appObserver.EmpolyeeHasChanged();

            model.Close();
        }
    }
}
