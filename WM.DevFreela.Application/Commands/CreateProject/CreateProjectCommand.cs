using MediatR;

namespace WM.DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int ClienteId { get; set; }
        public int FreelanderId { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
    }
}
