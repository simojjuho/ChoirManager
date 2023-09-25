namespace ChoirManager.Core.Abstractions;

public interface IWithId : ITimeProps
{
    Guid Id { get; set; }
}