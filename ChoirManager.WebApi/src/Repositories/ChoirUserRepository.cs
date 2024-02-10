using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace ChoirManager.WebApi.Repositories;

public class ChoirUserRepository : RepositoryProps<ChoirUser>, IChoirUserRepository
{
   
    public ChoirUserRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<ChoirUser[]> GetAllAsync(IQueryOptions queryOptions)
    {
        var memberships = queryOptions.OrderDesc
            ? _dbSet.OrderByDescending(props => props.MembershipId)
            : _dbSet.OrderBy(props => props.MembershipId);
        
        return await memberships
            .Skip((queryOptions.Page - 1) * queryOptions.PerPage)
            .Take(queryOptions.PerPage)
            .ToArrayAsync();
    }
    
    public async Task<ChoirUser?> GetOneAsync(string altKey)
    {
        var entity = await _dbSet.FindAsync(altKey);
        if (entity is null)
        {
            throw CustomException.NotFoundException("Choir membership does not exist");
        }

        return entity;
    }

    public async Task<ChoirUser> GetOneByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            throw CustomException.NotFoundException("Choir does not exist");
        }

        return entity;
    }

    public async Task<ChoirUser> CreateOneAsync(ChoirUser entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<ChoirUser> UpdateAsync(ChoirUser entity)
    {
        var entry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> RemoveAsync(ChoirUser entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}