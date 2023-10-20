using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, int clienteId, int freelanderId, decimal totalCost, string description, string clienteFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            ClienteId = clienteId;
            TotalCost = totalCost;
            Description = description;
            FreelanderId = freelanderId;
            ClienteFullName = clienteFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public int ClienteId { get; private set; }
        public int FreelanderId { get; private set; }
        public decimal TotalCost { get; private set; }
        public string Description { get; private set; }  
        public string ClienteFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
    }
}
