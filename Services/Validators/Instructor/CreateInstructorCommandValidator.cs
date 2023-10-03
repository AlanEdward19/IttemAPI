using FluentValidation;
using System.Text.RegularExpressions;

namespace Services.Validators.Instructor;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("E-mail não válido!");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        RuleFor(p => p.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Primeiro nome é obrigatório!");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Ultimo nome é obrigatório!");
    }

    public bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}