namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class TeacherConfiguration : BaseSettingsEntityConfiguration<Teacher> , IEntityTypeConfiguration<Teacher>
    {
        public virtual new void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.ToTable("Teacher");
        }
    }
}
