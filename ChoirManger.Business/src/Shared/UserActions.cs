using System.Text.RegularExpressions;
using ChoirManager.Core.CoreEntities;

namespace ChoirManger.Business.Shared;

public class UserActions
{
    public static List<User> ParseUser(string emailString)
    {
        var emailAddresses = ParseEmails(emailString);
        List<User> newUsers = new();
        foreach (var emailAddress in emailAddresses)
        {
            var user = new User();
            user.Email = emailAddress;
            newUsers.Add(user);
        }

        return newUsers;
    }

    private static List<string> ParseEmails(string emailString)
    {
        List<string> emailList = new();
        var tempList = emailString.Split(',');
        foreach (var email in tempList)
        {
            var regex = new Regex(@"\w{1,}@\w{1,}.\w{2,}", RegexOptions.IgnoreCase);
            if (regex.IsMatch(email))
            {
                emailList.Add(email);
            }
        }

        return emailList;
    }
}