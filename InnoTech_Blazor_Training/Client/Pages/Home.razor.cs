namespace InnoTech_Blazor_Training.Client.Pages
{
    public partial class Home
    {
        [Inject] public HttpClient _client { get; set; }
        public Empolyee employee { get; set; } = new();
        public Student student { get; set; } = new();

        public async Task SaveEmpolyeeToDb() => await _client.PostAsJsonAsync<Empolyee>("api/empolyee", employee);
        public async Task SaveStudentToDb() => await _client.PostAsJsonAsync<Student>("api/student", student);

        //protected override async Task OnParametersSetAsync()
        //{
        //    await client.GetFromJsonAsync<Empolyee>($"api/employees/{id}");
        //}

    }
}
