using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Test.ChoirManager.Business.SharedTestData;

public static class Choir_TestData
{
    public static Choir Choir =>
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Kristalli",
            Location = "Orivesi",
            FoundedAt = new DateOnly(1994, 11, 20),
            CreatedAt = DateTimeOffset.Now.ToUniversalTime(),
            UpdatedAt = DateTimeOffset.Now.ToUniversalTime()
        };
}