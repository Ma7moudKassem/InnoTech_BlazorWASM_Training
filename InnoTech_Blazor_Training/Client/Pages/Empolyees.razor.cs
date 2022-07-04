namespace InnoTech_Blazor_Training.Client.Pages
{
    public partial class Empolyees
    {
        [Inject] public HttpClient? _client { get; set; }
        List<Empolyee>? empolyees = new();
        public async Task<List<Empolyee>?> GetStudentDataFromDB() => await _client.GetFromJsonAsync<List<Empolyee>>("api/empolyee");
        protected override async Task OnInitializedAsync() => empolyees = await GetStudentDataFromDB();
    }
}
