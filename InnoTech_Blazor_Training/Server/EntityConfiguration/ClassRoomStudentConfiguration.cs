namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class ClassRoomStudentConfiguration : IEntityTypeConfiguration<ClassRoomStudent>
    {
        public void Configure(EntityTypeBuilder<ClassRoomStudent> builder)
        {
            
            builder.ToTable("ClassRoomStudent");

            builder.HasKey(e => new { e.ClassRoomId, e.StudentId });

            builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId)
                                                     .HasConstraintName("fk-classroomstudent-student");
        }
    }
}
