namespace InnoTech_Blazor_Training.Server.BaseUnitOfWork
{
    public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        public BaseUnitOfWork(IBaseRepository<TEntity> repository)=> _repository = repository;

        public async Task<IEnumerable<TEntity>> Read() =>await _repository.Get();
        public async Task<TEntity> Read(Guid id) =>await _repository.Get(id);

        public virtual async Task Create(TEntity entity) 
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Add(entity);

            await transaction.CommitAsync();
        }
        public async Task Create(IEnumerable<TEntity> entities)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Add(entities);

            await transaction.CommitAsync();
        }

        public async Task Update(TEntity entity)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Update(entity);

            await transaction.CommitAsync();
        }
        public virtual async Task Update(List<TEntity> entities)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Update(entities);

            await transaction.CommitAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Remove(id);

            await transaction.CommitAsync();
        }
        public virtual async Task Delete(TEntity entity)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Remove(entity);

            await transaction.CommitAsync();
        }
        public virtual async Task Delete(IEnumerable<TEntity> entites)
        {
            using IDbContextTransaction transaction = await _repository.GetTransaction();

            await _repository.Remove(entites);

            await transaction.CommitAsync();
        }
        public void Dispose() =>  _repository.Dispose();
    }
}
