namespace InnoTech_Blazor_Training.Shared.Entities
{
    public class ClassRoomStudent : BaseEntity
    {
        public Guid ClassRoomId { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
