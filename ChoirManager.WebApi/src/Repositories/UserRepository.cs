using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace ChoirManager.WebApi.Repositories;

public class UserRepository : RepositoryProps<User>, IUserRepository
{
    public UserRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<User[]> GetAllAsync(IQueryOptions queryOptions)
    {
        var users = queryOptions.OrderDesc
            ? _dbSet.OrderByDescending(props => props.Name)
            : _dbSet.OrderBy(props => props.Name);
        
        return await users
            .Skip((queryOptions.Page - 1) * queryOptions.PerPage)
            .Take(queryOptions.PerPage)
            .ToArrayAsync();
    }

    public async Task<User?> GetOneAsync(string altKey)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(prop => prop.Name.ToLower() == altKey.ToLower());
        if (entity is null)
        {
            throw CustomException.NotFoundException("User does not exist");
        }

        return entity;
    }

    public async Task<User> GetOneByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            throw CustomException.NotFoundException("Choir does not exist");
        }

        return entity;
    }

    public async Task<User> CreateOneAsync(User entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var entry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> RemoveAsync(User entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}