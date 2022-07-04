namespace InnoTech_Blazor_Training.Server.EntityConfiguration
{
    public class BaseSettingsEntityConfiguration<TEntity> : BaseConfiguration<TEntity> ,IEntityTypeConfiguration<TEntity>
        where TEntity : BaseSettingsEntity
    {
        public virtual new void  Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
