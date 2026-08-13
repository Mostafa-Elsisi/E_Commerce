using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Contracts
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id,CancellationToken ct);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> spec,CancellationToken ct);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct);
        Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey> spec,CancellationToken ct);
        Task<int> CountAsync(ISpecifications<TEntity, TKey> spec, CancellationToken ct);
    }
}
