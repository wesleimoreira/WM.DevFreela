using MediatR;

namespace WM.DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
    }
}
