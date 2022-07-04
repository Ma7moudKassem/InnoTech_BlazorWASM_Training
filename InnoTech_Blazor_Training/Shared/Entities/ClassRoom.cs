namespace InnoTech_Blazor_Training.Shared.Entities
{
    public class ClassRoom : BaseSettingsEntity 
    {
        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student>? Students { get; set; }
        public List<ClassRoomStudent>? ClassRoomStudent { get; set; }
    }
}
