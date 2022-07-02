namespace InnoTech_Blazor_Training.Client.Pages
{
    public partial class StudentComponent
    {
        [Inject] public HttpClient _client { get; set; }

        List<Student>? students = new();
        Student student = new(); 
        public async Task SaveStudentDataToDB()
        {
            await _client.PostAsJsonAsync<Student>("api/students" , student);
             StateHasChanged();
            students = await GetStudentDataFromDB();
        }

        public async Task<List<Student>?> GetStudentDataFromDB() => await _client.GetFromJsonAsync<List<Student>>("api/students");

        protected override async Task OnInitializedAsync() =>
            students = await GetStudentDataFromDB();

    }
}
