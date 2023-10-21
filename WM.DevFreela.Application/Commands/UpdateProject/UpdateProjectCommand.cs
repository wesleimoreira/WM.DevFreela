using MediatR;

namespace WM.DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
    }
}
