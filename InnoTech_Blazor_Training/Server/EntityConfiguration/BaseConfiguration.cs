namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>();
        }
    }
}
