using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.WebApi.Database;
using ChoirManager.Business.Shared;
using Microsoft.EntityFrameworkCore;

namespace ChoirManager.WebApi.Repositories;

public class ChoirRepository : RepositoryProps<Choir>, IChoirRepository
{
    public ChoirRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<Choir[]> GetAllAsync(IChoirQueryOptions queryOptions)
    {
        var choirs = _dbSet.Where(property => property.Name.Contains(queryOptions.Filter));
        if (queryOptions.OrderDesc)
        {
            return await choirs
                .OrderByDescending(prop => prop.Name)
                .Skip((queryOptions.Page - 1) * queryOptions.PerPage)
                .Take(queryOptions.PerPage)
                .ToArrayAsync();
        }
        return await choirs
            .OrderByDescending(prop => prop.Name)
            .Skip((queryOptions.Page - 1) * queryOptions.PerPage)
            .Take(queryOptions.PerPage)
            .ToArrayAsync();
    }

    public async Task<Choir?> GetOneAsync(string altKey)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(prop => prop.Name.ToLower().Contains(altKey.ToLower()));
        if (entity is null)
        {
            throw CustomException.NotFoundException("Choir does not exist");
        }

        return entity;
    }

    public async Task<Choir> GetOneByIdAsync(Guid id)
    {
        var choir = await _dbSet.FindAsync(id);
        if (choir is null)
        {
            throw CustomException.NotFoundException("Choir does not exist");
        }

        return choir;
    }

    public async Task<Choir> CreateOneAsync(Choir entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Choir> UpdateAsync(Choir entity)
    {
        var entry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> RemoveAsync(Choir entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}