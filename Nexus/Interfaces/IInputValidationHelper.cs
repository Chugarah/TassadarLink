using System.ComponentModel.DataAnnotations;
using Core.DTOs;

namespace Nexus.Interfaces;

public interface IInputValidationHelper
{
    ValidationResult ValidateRequired(string? text, string displayName);
    ValidationResult ValidateMinLength(string? text, string displayName, int minLength = 2);
    ValidationResult ValidatePattern(string? text, string pattern, string property, string displayName);
}

