namespace InnoTech_Blazor_Training.Server.BaseUnitOfWork
{
    public interface IBaseSettingsUnitOfWork<TEntity> :IBaseUnitOfWork<TEntity> , IDisposable where TEntity : BaseSettingsEntity
    {
        Task<IEnumerable<TEntity>> Search(string searchText);
    }
}
