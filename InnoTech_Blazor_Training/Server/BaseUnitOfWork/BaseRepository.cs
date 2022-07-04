namespace InnoTech_Blazor_Training.Server.BaseUnitOfWork
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> dbSet;
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }
        public virtual async Task Add(TEntity entity)
        {
            ThrowExceptionIfParametarIsNotSupplied(entity);
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }
        public virtual async Task Add(IEnumerable<TEntity> entities)
        {
            ThrowExceptionIfParametarIsNotSupplied(entities);
            await dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get() => await dbSet.ToListAsync();
        public virtual async Task<TEntity> Get(Guid id) => await
                                               dbSet.FirstOrDefaultAsync(e => e.Id == id) ??
                                               Activator.CreateInstance<TEntity>();

        public virtual async Task Update(List<TEntity> entities)
        {
            ThrowExceptionIfParametarIsNotSupplied(entities);

            foreach (TEntity entity in entities)
                await Update(entity , false);

            await SaveChangesAsync();
        }
        public virtual async Task Update(TEntity entity , bool isAutoSaveChangeEnabeled = true)
        {
            ThrowExceptionIfParametarIsNotSupplied(entity);

            await ThrowExceptionIfEntityIsExistsInDb(entity);

            await Task.Run(() => dbSet.Update(entity));
            if(isAutoSaveChangeEnabeled)
                await SaveChangesAsync();
        }
        private async Task ThrowExceptionIfEntityIsExistsInDb(TEntity entity)
        {
            if (entity.Id == null && entity.Id != Guid.Empty)
                throw new ArgumentNullException($"Id of {typeof(TEntity).Name} is null or guid is not empty");
            TEntity entityFromDb = await Get(entity.Id.Value);
            if (entityFromDb == null)
                throw new ArgumentNullException($"{nameof(entity)} was not existing in Database");
        }
        private async Task<TEntity> GetEntityFromDatabase(TEntity entity)
        {
            TEntity? entityFromDb = await Get(entity.Id.Value);
            if (entityFromDb == null)
                throw new ArgumentNullException($"{nameof(entity)} was not existing in Database");

            return entityFromDb;
        }

        public virtual async Task Remove(Guid id)
        {
            TEntity? entityFromDb = await Get(id);
            if (entityFromDb == null)
                throw new ArgumentNullException($"{nameof(TEntity)} was not found in database");

            await Task.Run(() => dbSet.Remove(entityFromDb));
            await SaveChangesAsync();
          
        }
        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null || entity.Id == null)
                throw new ArgumentNullException($"{nameof(TEntity)} was not found in database");

            TEntity? entityFromDb = await Get(entity.Id.Value);

            await Task.Run(() => dbSet.Remove(entityFromDb));
            await SaveChangesAsync();
        }
        public virtual async Task Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException($"{nameof(TEntity)} was not provided");

            await Task.Run(()=> dbSet.RemoveRange(entities));
            await SaveChangesAsync();
        }

        private static void ThrowExceptionIfParametarIsNotSupplied(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(entity)} was not provided");
        } 
        private static void ThrowExceptionIfParametarIsNotSupplied(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException($"{nameof(TEntity)} was not provided");
        }
        public virtual async Task<IDbContextTransaction> GetTransaction() => await _context.Database.BeginTransactionAsync();
        protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

    }
}
