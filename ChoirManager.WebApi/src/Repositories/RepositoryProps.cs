using ChoirManager.Core.Abstractions;
using ChoirManager.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace ChoirManager.WebApi.Repositories;

public class RepositoryProps<T> where T : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected RepositoryProps(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
}