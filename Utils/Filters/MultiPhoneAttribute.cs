using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Login.Utils.Filters;

/// <summary>
/// Checks if the list of number is valid.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false
)]
public class MultiPhoneAttribute : ValidationAttribute
{
    private const string PhoneNumberPattern = @"^[0-9]\d{1,2}-?\d{6,8}$";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not IEnumerable<string> phoneNumbers)
        {
            return new ValidationResult("The value must be an IEnumerable<string>.");
        }

        foreach (var phoneNumber in phoneNumbers)
        {
            if (!Regex.IsMatch(phoneNumber, PhoneNumberPattern))
            {
                return new ValidationResult(
                    $"{phoneNumber} is not a valid phone number.",
                    new[] { validationContext.MemberName }
                );
            }
        }

        return ValidationResult.Success;
    }
}
