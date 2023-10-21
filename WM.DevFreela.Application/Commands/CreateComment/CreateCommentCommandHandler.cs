using MediatR;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.AddAsync(new ProjectComment(request.Content, request.UserId, request.ProjectId));

            return Unit.Value;
        }
    }
}
