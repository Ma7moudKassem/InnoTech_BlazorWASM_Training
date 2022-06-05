namespace InnoTech_Blazor_Training.Shared
{
    public class Empolyee : BaseEntity
    {
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public string? Telephone { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
