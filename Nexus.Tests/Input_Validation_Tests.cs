using System.ComponentModel.DataAnnotations;
using Nexus.Helpers;
using Nexus.Interfaces;

namespace Nexus.Tests;

public class InputValidationTests()
{

    // I cant put that in primary constructor because it is not allowed in xUnit tests
    private readonly IInputValidationHelper _inputValidationHelper = new InputValidationHelper();

    /// <summary>
    /// Theory attribute is used to indicate that this is a parameterized test
    /// https://code--maze-com.translate.goog/xunit-how-to-pass-complex-parameters-to-theory/?_x_tr_sl=en&_x_tr_tl=sv&_x_tr_hl=sv&_x_tr_pto=sc
    /// Combination of the url above and the Phind AI to refactor and helping me to help to build this test
    /// using parameterized tests to test the ValidateRequired method from the InputValidationHelper class
    /// Thanks this test I had to change the ValidateRequired to use Whitespace validation as well and not just
    /// empty string validation
    /// </summary>
    /// <param name="input"></param>
    /// <param name="displayName"></param>
    [Theory]
    [InlineData(null, "First Name")]
    [InlineData("", "First Name")]
    [InlineData(" ", "First Name")]
    public void ValidateRequired_WithEmptyInput_ReturnsError(string? input, string displayName)
    {
        // ACT
        var result = _inputValidationHelper.ValidateRequired(input, displayName);

        // ASSERT
        Assert.False(result == ValidationResult.Success);
        Assert.NotNull(result.ErrorMessage);
        Assert.Equal($"{displayName} cannot be empty", result.ErrorMessage);
    }

    [Fact]
    public void Validation_WithValidInput_ReturnsSuccess()
    {
        // Arrange
        const string input = "Starcraft";
        const string displayName = "First Name";

        // ACT
        var result = _inputValidationHelper.ValidateRequired(input, displayName);

        // ASSERT
        Assert.True(result == ValidationResult.Success);
        Assert.Null(result?.ErrorMessage);
    }
}