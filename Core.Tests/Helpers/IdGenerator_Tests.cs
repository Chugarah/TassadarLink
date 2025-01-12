using Core.Factories;
using Core.Helpers;

namespace Core.Tests.Helpers;

public class IdGeneratorTests
{
   private readonly IdHelpers _idHelpers = new();

    /// <summary>
    /// Inspired by Hans
    /// </summary>
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
        // ACT
        var result = _idHelpers.CreateGuid();

        // ASSERT
        Assert.NotNull(result);
        Assert.IsType<Guid>(result);
    }

    /// <summary>
    /// I used ChatGPT to help me generate this test to return the next id in the list
    /// </summary>
    [Fact]
    public void GetNextId_ShouldReturnNextId()
    {
        // ARRANGE
        var list = new List<int> { 1, 2, 3, 4, 5 };

        // ACT
        var result = _idHelpers.GetNextId(list, i => i);

        // ASSERT
        Assert.Equal(6, result);
    }

    /// <summary>
    /// This test builds on the first one but without sequence numbering
    /// </summary>
    [Fact]
    public void GetNextId_WithOutSequenceNumbering_ShouldReturnNextId()
    {
        // ARRANGE
        var list = new List<int> { 1, 3, 11, 52, 4 };

        // ACT
        var result = _idHelpers.GetNextId(list, i => i);

        // ASSERT
        Assert.Equal(53, result);
    }

    
}