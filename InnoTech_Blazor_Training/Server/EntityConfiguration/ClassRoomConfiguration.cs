

namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class ClassRoomConfiguration : BaseSettingsEntityConfiguration<ClassRoom>, 
                                          IEntityTypeConfiguration<ClassRoom>
    {
        public virtual new void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClassRoom");

            builder.HasOne(e => e.Subject).WithMany().HasForeignKey(e => e.SubjectId)
                                                     .HasConstraintName("fk-classroom-subject");
            builder.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId)
                                                     .HasConstraintName("fk-classroom-teacher");
            builder.HasMany(e => e.ClassRoomStudent).WithOne().HasForeignKey(e => e.ClassRoomId)
                                                      .HasConstraintName("fk-classroom-classroomstudents");
        }
    }
}
