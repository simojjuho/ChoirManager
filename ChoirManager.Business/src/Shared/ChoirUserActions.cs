using System.Runtime.InteropServices.JavaScript;
using ChoirManager.Business.Abstractions.Shared;

namespace ChoirManager.Business.Shared;

public class ChoirUserActions : IChoirUserActions
{
    public string CreateMembershipId(string choirName)
    {
        var date = DateTime.Now;
        var choirLetters = choirName.Substring(0, 4);
        var year = DateTime.Now.Year.ToString().Substring(2);
        var randomInt = new Random().Next(1000, 9999).ToString();
        var seconds = DateTime.Now.Microsecond.ToString();
        
        return $"{choirLetters}{year}-{randomInt}-{seconds}";
    }
}