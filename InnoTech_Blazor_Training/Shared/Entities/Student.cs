namespace InnoTech_Blazor_Training.Shared
{
    public class Student : BaseSettingsEntity
    {
        public double GPA { get; set; }
        public string? Mobile { get; set; }
        public string? Grade { get; set; }
        public DateTime BirthDay { get; set; }

    }
}
