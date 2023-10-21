using FluentValidation;
using WM.DevFreela.Application.Commands.CreateComment;

namespace WM.DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Texto de Comentário é de 255 caracteres.");
        }
    }
}
