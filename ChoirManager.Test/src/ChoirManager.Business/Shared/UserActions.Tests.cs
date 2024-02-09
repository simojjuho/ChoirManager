using ChoirManager.Business.Shared;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Test.ChoirManager.Business.Shared;

public class UserActions_Tests
{
    [Fact]
    public void ParseUser_ShouldParse()
    {
        // Arrange
        var emailString = "john.fogerty@ccr.com,bon@jovi.com,aretha.franklin.com";
        var listOfUsers = new List<User>();
        var listOfEmails = new List<string>() { "john.fogerty@ccr.com", "bon@jovi.com", "aretha.franklin.com" };

        //Act
        var users = UserActions.ParseUser(emailString);

        //Assert
        Assert.IsType<List<User>>(users);
        Assert.Equivalent("bon@jovi.com",users[1].Email );
    }
}