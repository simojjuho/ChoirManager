namespace ChoirManager.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    T GetAll();
    T GetOneByAltKey(string altKey);
    T CreateOne(T entity);
    T Update(T entity);
    T Remove(T entity);
}