namespace InnoTech_Blazor_Training.Shared
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public double GPA { get; set; }
        public string? Mobile { get; set; }
        public string? Grade { get; set; }
    }
}
