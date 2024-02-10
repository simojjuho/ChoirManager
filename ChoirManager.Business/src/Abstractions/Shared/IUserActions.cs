using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Abstractions.Shared;

public interface IUserActions
{
    List<User> ParseUser(string emailString);
    List<string> ParseEmails(string emailString);
}