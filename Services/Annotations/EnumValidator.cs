using System.ComponentModel.DataAnnotations;

namespace Services.Annotations;

public class EnumValidator : ValidationAttribute
{
    public Type EnumType { get; set; }
    public string[]? ForceInvalidValues { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is "")
            return ValidationResult.Success;

        if (value is null)
        {
            throw new Exception($"Nenhum parametro foi especificado {validationContext.DisplayName}");
        }

        if (Enum.TryParse(EnumType, value.ToString(), true, out var result))
        {
            if (ForceInvalidValues is not null)
                if (ForceInvalidValues.ToList().Contains(result.ToString(), StringComparer.InvariantCultureIgnoreCase))
                    throw new Exception($"Invalid value: {value} for {EnumType} {validationContext.DisplayName}");
        }
        else
        {
            throw new Exception($"Invalid value: {value} for {EnumType} {validationContext.DisplayName}");
        }

        return ValidationResult.Success;
    }
}