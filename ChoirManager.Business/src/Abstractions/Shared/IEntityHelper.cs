namespace ChoirManager.Business.Abstractions.Shared;

public interface IEntityHelper<T>
{
    public void ReplacePropertyValues(T original, T update);
    public void CheckNullValues(T original, T update);
}