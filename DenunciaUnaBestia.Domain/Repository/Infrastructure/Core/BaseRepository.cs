using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Dependencies.Context;
using DenunciaUnaBestia.Domain.Repository.Infrastructure.Interfaces;

namespace DenunciaUnaBestia.Domain.Repository.Infrastructure.Core;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DenunciaUnaBestiaContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DenunciaUnaBestiaContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
