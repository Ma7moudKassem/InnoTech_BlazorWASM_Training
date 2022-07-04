namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class SubjectConfiguration : BaseSettingsEntityConfiguration<Subject> , IEntityTypeConfiguration<Subject>
    {
        public virtual new void Configure(EntityTypeBuilder<Subject> builder)
        {
            base.Configure(builder);
            builder.ToTable("SubjectConfiguration ");
        }
    }
}
