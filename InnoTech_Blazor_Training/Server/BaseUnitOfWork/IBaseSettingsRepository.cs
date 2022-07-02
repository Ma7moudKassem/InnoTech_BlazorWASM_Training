namespace InnoTech_Blazor_Training.Server.BaseUnitOfWork
{
    public interface IBaseSettingsRepository<TEntity> : IBaseRepository<TEntity> , IDisposable where TEntity : BaseSettingsEntity
    {
        Task<IEnumerable<TEntity>> Search(string searchText);
    }
}
