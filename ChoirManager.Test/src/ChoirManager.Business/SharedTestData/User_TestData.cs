using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.Enums;

namespace ChoirManager.Test.ChoirManager.Business.SharedTestData;

public static class User_TestData
{
    public static User User =>
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "New",
            LastName = "User",
            Email = "new@user.fi",
            Status = ProfileStatus.Active,
            CreatedAt = DateTimeOffset.Now.ToUniversalTime(),
            UpdatedAt = DateTimeOffset.Now.ToUniversalTime()
        };
}