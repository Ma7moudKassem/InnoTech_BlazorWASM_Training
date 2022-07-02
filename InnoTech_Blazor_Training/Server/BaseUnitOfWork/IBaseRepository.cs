namespace InnoTech_Blazor_Training.Server.BaseUnitOfWork
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(Guid id);
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entity);
        Task Update(TEntity entity, bool isAutoSaveChangeEnabeled = true);
        Task Update(List<TEntity> entities);
        Task Remove(TEntity entity);
        Task Remove(IEnumerable<TEntity> entity);
        Task Remove(Guid id);
        Task<IDbContextTransaction> GetTransaction();
    }
}
