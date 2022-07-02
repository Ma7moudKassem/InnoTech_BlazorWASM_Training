namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class EmpolyeeConfiguration : BaseConfiguration<Empolyee>
    {
        public void Configure(EntityTypeBuilder<Empolyee> builder)
        {
            base.Configure(builder);
            builder.ToTable("OurEmpoyees");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.BirthDay).IsRequired();
            builder.Property(e => e.Mobile).HasMaxLength(20);
            builder.Property(e => e.Telephone).HasMaxLength(20);
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
