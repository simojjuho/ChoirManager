namespace ChoirManger.Business.Shared;

public static class EntityHelper<T>
{
    public static void ReplaceProperyValues(T original, T update)
    {
        var newProps = update.GetType().GetProperties();
        foreach (var property in newProps)
        {
            if (property.CanWrite)
            {
                property.SetValue(original, update!.GetType().GetProperty(property.Name)!.GetValue(update));
            }
        }
    }
    
    public static void CheckNullValues(T original, T update)
    {
        var newProps = update.GetType().GetProperties();
        foreach (var property in newProps)
        {
            if (!property.CanWrite) continue;
            if (update.GetType().GetProperty(property.Name)!.GetValue(update) is null)
            {
                property.SetValue(update, original!.GetType().GetProperty(property.Name)!.GetValue(original));
            }
        }
    }
}