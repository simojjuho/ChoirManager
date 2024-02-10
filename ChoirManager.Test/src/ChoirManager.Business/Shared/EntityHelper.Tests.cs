using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.Shared;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Test.ChoirManager.Business.Shared;

public class EntityHelper_Tests
{
    private IEntityHelper<Choir> _entityHelper;

    public EntityHelper_Tests()
    {
        _entityHelper = new EntityHelper<Choir>();
    }
    
    [Fact]
    public void ReplacePropertyValues_ShouldChangeValues()
    {
        var origChoir = new Choir()
        {
            Name = "OldName",
            Location = "OldTown",
            FoundedAt = new DateOnly(1994, 12, 1)
        };
        var updateChoir = new Choir()
        {
            Name = "NewName",
            Location = "NewTown",
            FoundedAt = new DateOnly(1992, 12, 1)
        };
        
        _entityHelper.ReplacePropertyValues(origChoir, updateChoir);
        
        Assert.Equal(updateChoir.Name, origChoir.Name);
        Assert.Equal(updateChoir.Location, origChoir.Location);
        Assert.Equal(updateChoir.FoundedAt, origChoir.FoundedAt);
    }
    
    [Fact]
    public void CheckNullValues_ShouldChangeValues()
    {
        var origChoir = new Choir()
        {
            Name = "OldName",
            Location = "OldTown",
            FoundedAt = new DateOnly(1994, 12, 1)
        };
        var updateChoir = new Choir()
        {
            FoundedAt = new DateOnly(1992, 12, 1)
        };
        
        _entityHelper.CheckNullValues(origChoir, updateChoir);
        
        Assert.Equal("OldName", origChoir.Name);
        Assert.Equal("OldTown", updateChoir.Location);
        Assert.Equal(new DateOnly(1992, 12, 1), updateChoir.FoundedAt);
    }
}