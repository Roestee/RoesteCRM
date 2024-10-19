using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RoesteCrmServer.Domain.Abstract.EntityFrameworkCore;

public class EfRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<TEntity> _entity;

    public EfRepository(TContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _entity.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _entity.AddRangeAsync(entities, cancellationToken);
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return _entity.Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _entity.AnyAsync(expression, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public async Task DeleteByExpression(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var entity = await _entity.Where(filter).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        _entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _entity.FindAsync(id, cancellationToken);
        _entity.Remove(entity);
    }

    public void DeleteRange(ICollection<TEntity> entities)
    {
        _entity.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        _entity.UpdateRange(entities);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _entity.AsNoTracking().AsQueryable();
    }

    public IQueryable<TEntity> GetAllWithTracking()
    {
        return _entity.AsQueryable();
    }

    public TEntity GetFirst()
    {
        return _entity.AsNoTracking().FirstOrDefault();
    }

    public async Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        return await _entity.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
    {
        return _entity.AsNoTracking().Where(filter).AsQueryable();
    }

    public IQueryable<TEntity> WhereWithTracking(Expression<Func<TEntity, bool>> filter)
    {
        return _entity.Where(filter).AsQueryable();
    }
}
