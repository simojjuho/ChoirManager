using Autofac.Extras.Moq;
using ChoirManager.Business.Abstractions.Shared;

using ChoirManager.Business.Shared;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Test.ChoirManager.Business.Shared;

public class UserActions_Tests
{
    private IUserActions _userActions;

    public UserActions_Tests()
    {
        _userActions = new UserActions();
    }
    
    [Fact]
    public void ParseUser_ShouldParse()
    {
        using var mock = AutoMock.GetLoose();
        var emailString = "john.fogerty@ccr.com,bon@jovi.com,aretha@franklin.com";
        var expected = new List<string>
        {
            "john.fogerty@ccr.com",
            "bon@jovi.com",
            "aretha@franklin.com"
        };
        mock.Mock<IUserActions>()
            .Setup(x => x.ParseEmails(emailString))
            .Returns(expected);

        var userParser = mock.Create<UserActions>();
        var actual = userParser.ParseUser(emailString);
            
        Assert.True(actual != null);
        foreach (var user in actual)
        {
            Assert.Contains<string>(user.Email, expected);

        }
    }

    [Fact]
    public void ParseEmails_DiscardInvalidEmails()
    {
        var emailString = "john.fogerty@ccr.com,bon@jovi.com,aretha@franklin.com,@usa.com,president@.com,president@usa";
        var emailList = _userActions.ParseEmails(emailString);
        var expected = new List<string>
        {
            "john.fogerty@ccr.com",
            "bon@jovi.com",
            "aretha@franklin.com"
        };
        var notExpected = new List<string>
        {
            "@usa.com",
            "president@.com",
            "president@usa"
        };
        
        Assert.True(emailList.Count == 3);
        foreach (var email in expected)
        {
            Assert.Contains<string>(email, emailList);
        }
        
        foreach (var email in notExpected)
        {
            Assert.DoesNotContain<string>(email, emailList);
        }
    }
}