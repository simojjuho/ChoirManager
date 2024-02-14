using Autofac.Extras.Moq;
using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Business.Services;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;
using ChoirManager.Test.ChoirManager.Business.SharedTestData;
using Moq;

namespace ChoirManager.Test.ChoirManager.Business.Services;

public class ChoirUserService_Test
{
    [Fact]
    public async void Create_ShouldWork()
    {
        using var mock = AutoMock.GetLoose();

        var newChoirUserDto = ChoirUser_TestData.ChoirUserCreateDto;
        var expected = ChoirUser_TestData.ChoirUserGetDto;
        var choirUserFromRepo = ChoirUser_TestData.ChoirUser;
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

        var service = mock.Create<ChoirUserService>();
        var actual = await service.CreateOneAsync(newChoirUserDto);
        
        mock.Mock<IUserRepository>()
            .Verify(x => x.GetOneAsync(newChoirUserDto.UserEmail), Times.Exactly(1));
        Assert.Equal(expected.MembershipId, actual.MembershipId);
        Assert.Equal(expected.MembershipStatus, actual.MembershipStatus);
        Assert.Equal(expected.UserRole, expected.UserRole);
    }

    [Fact]
    public async void Create_ShouldThrowError()
    {
        using var mock = AutoMock.GetLoose();
        var newChoirUserDto = ChoirUser_TestData.ChoirUserCreateDto;
        mock.Mock<IChoirRepository>()
            .Setup(x => x.GetOneAsync(""));
        var service = mock.Create<ChoirUserService>();
        CustomException ex = Assert
            .ThrowsAsync<CustomException>(async () => await service.CreateOneAsync(newChoirUserDto)).Result;
        Assert.Equal("Choir does not exist", ex.ErrorMessage);
    }
}