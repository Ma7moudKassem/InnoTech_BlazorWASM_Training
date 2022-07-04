namespace InnoTech_Blazor_Training.Client.Pages
{
    public partial class Students
    {
        [Inject] public HttpClient? _client { get; set; }
        List<Student>? students = new();
        public async Task<List<Student>?> GetStudentDataFromDB() => await _client.GetFromJsonAsync<List<Student>>("api/student");
        protected override async Task OnInitializedAsync() => students = await GetStudentDataFromDB();
    }
}
