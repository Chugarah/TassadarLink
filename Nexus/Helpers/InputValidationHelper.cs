using System.ComponentModel.DataAnnotations;
using Core.DTOs;
using Core.Interface;
using Nexus.Interfaces;

namespace Nexus.Helpers;

public class InputValidationHelper : IInputValidationHelper
{
    public ValidationResult ValidateRequired(string? text, string displayName)
        => string.IsNullOrEmpty(text)
            ? new ValidationResult($"{displayName} cannot be empty")
            : ValidationResult.Success!;

    public ValidationResult ValidateMinLength(string? text, string displayName, int minLength = 2)
        => (text?.Length ?? 0) < minLength
            ? new ValidationResult($"The {displayName.ToLower()} must be at least {minLength} characters")
            : ValidationResult.Success!;

    public ValidationResult ValidatePattern(string? text, string pattern, string property, string displayName)
        => !System.Text.RegularExpressions.Regex.IsMatch(text ?? "", pattern)
            ? new ValidationResult(GetPatternErrorMessage(property, displayName))
            : ValidationResult.Success!;

    private static string GetPatternErrorMessage(string property, string displayName) => property switch
    {
        nameof(ContactDto.Email) => "Please enter a valid email address",
        nameof(ContactDto.PhoneNumber) => "Please enter a valid phone number (minimum 4 digits, XXXX)",
        _ => $"{displayName} must contain only letters"
    };
}
