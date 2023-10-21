using FluentValidation;
using System.Text.RegularExpressions;
using WM.DevFreela.Application.Commands.CreateUser;

namespace WM.DevFreela.Application.Validators
{
    public partial class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email).EmailAddress().WithMessage("E-mail não válido!");
            RuleFor(p => p.Password).Must(ValidPassword).WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
            RuleFor(p => p.FullName).NotEmpty().NotNull().WithMessage("Nome é obrigatório!");
        }

        private static bool ValidPassword(string password)
        {
            return MyRegex().IsMatch(password);
        }

        [GeneratedRegex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$")]
        private static partial Regex MyRegex();
    }
}
