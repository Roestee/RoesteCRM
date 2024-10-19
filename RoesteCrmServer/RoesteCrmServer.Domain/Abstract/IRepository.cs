using System.Linq.Expressions;

namespace RoesteCrmServer.Domain.Abstract;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllWithTracking();
    TEntity GetFirst();
    Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter);
    IQueryable<TEntity> WhereWithTracking(Expression<Func<TEntity, bool>> filter);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    bool Any(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void UpdateRange(ICollection<TEntity> entities);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task DeleteByExpression(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    void DeleteRange(ICollection<TEntity> entities);
}
