using System.Text.RegularExpressions;
using Autofac.Extras.Moq;
using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Business.Services;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;
using ChoirManager.Test.ChoirManager.Business.SharedTestData;
using ChoirManager.WebApi.Repositories;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ChoirManager.Test.ChoirManager.Business.Services;

public class ChoirUserService_Test
{
    private ITestOutputHelper _output;
    
    public ChoirUserService_Test(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public async void Create_ShouldWork()
    {
        using var mock = AutoMock.GetLoose();

        var newChoirUserDto = ChoirUserTestData.ChoirUserCreateDto;
        var expected = ChoirUserTestData.ChoirUserGetDto;
        var choirUserFromRepo = ChoirUserTestData.ChoirUser;
        mock.Mock<IUserRepository>()
            .Setup(x => x.GetOneAsync(newChoirUserDto.UserEmail))
            .Returns(Task.FromResult(User_TestData.User)!);
        mock.Mock<IChoirRepository>()
            .Setup(x => x.GetOneAsync(newChoirUserDto.ChoirName))
            .Returns(Task.FromResult(Choir_TestData.Choir)!);
        mock.Mock<IMapper>()
            .Setup(x => x.Map<ChoirUser>(newChoirUserDto))
            .Returns(choirUserFromRepo);
        mock.Mock<IChoirUserRepository>()
            .Setup(x => x.CreateOneAsync(choirUserFromRepo))
            .Returns(Task.FromResult(choirUserFromRepo));
        mock.Mock<IMapper>()
            .Setup(x => x.Map<ChoirUserGetDto>(choirUserFromRepo))
            .Returns(expected);
        mock.Mock<IChoirUserActions>()
            .Setup(x => x.CreateMembershipId("Kristalli"))
            .Returns("Kris24-5367-453");

        var service = mock.Create<ChoirUserService>();
        var actual = await service.CreateOneAsync(newChoirUserDto);
        mock.Mock<IUserRepository>()
            .Verify(x => x.GetOneAsync(newChoirUserDto.UserEmail), Times.Exactly(1));
        Assert.Equal(expected.MembershipId, actual.MembershipId);
        Assert.Equal(expected.MembershipStatus, actual.MembershipStatus);
        Assert.Equal(expected.UserRole, expected.UserRole);
    }

    [Fact]
    public void Create_ShouldThrowError()
    {
        using var mock = AutoMock.GetLoose();
        var newChoirUserDto = ChoirUserTestData.ChoirUserCreateDto;
        mock.Mock<IChoirRepository>()
            .Setup(x => x.GetOneAsync(""));
        var service = mock.Create<ChoirUserService>();
        CustomException ex = Assert
            .ThrowsAsync<CustomException>(async () => await service.CreateOneAsync(newChoirUserDto)).Result;
        Assert.Equal("Choir does not exist", ex.ErrorMessage);
    }

    [Theory]
    [InlineData("Kristalli")]
    public void CreateMembershipId_ShouldCreate(string choirName)
    {
        var choirUserActions = new ChoirUserActions();
        var membershipId = choirUserActions.CreateMembershipId(choirName);
        var year = DateTime.Now.Year.ToString().Substring(2);
        var choirSubstring = choirName.Substring(0, 4);
        _output.WriteLine(membershipId);
        var regexPattern = choirSubstring + year + "-[0-9]{4}-[0-9]{3}";
        Assert.Matches(regexPattern, membershipId);
    }
}