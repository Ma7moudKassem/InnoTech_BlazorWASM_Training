namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class StudentConfiguration : BaseConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            builder.ToTable("StudentsTable");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.GPA).IsRequired();
            builder.Property(e => e.Mobile).HasMaxLength(20);
            builder.Property(e => e.Grade).HasMaxLength(30);
        }
    }
}
