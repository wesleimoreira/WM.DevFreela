using WM.DevFreela.Core.Enums;

namespace WM.DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, int clienteId, int freelancerId, decimal totalCost, string description)
        {
            Title = title;
            ClienteId = clienteId;
            TotalCost = totalCost;
            Description = description;
            FreelancerId = freelancerId;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public decimal TotalCost { get; private set; }
        public string Description { get; private set; }

        public DateTime? CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public IEnumerable<ProjectComment> Comments { get; private set; }

        // propriedades de navegação
        public int ClienteId { get; private set; }
        public User Client { get;  set; }
        public int FreelancerId { get; private set; }
        public User Freelancer { get;  set; }

        public void Start()
        {
            if (this.Status == ProjectStatusEnum.Created)
            {
                this.Status = ProjectStatusEnum.InProgress;
                this.StartedAt = DateTime.Now;
            }
        }
        public void Cancel()
        {
            if (this.Status == ProjectStatusEnum.InProgress)
                this.Status = ProjectStatusEnum.Cancelled;
        }
        public void Finish()
        {
            if (this.Status == ProjectStatusEnum.InProgress)
            {
                this.Status = ProjectStatusEnum.Finished;
                this.FinishedAt = DateTime.Now;
            }
        }
        public void SetPaymentPending()
        {
            Status = ProjectStatusEnum.PaymentPending;
            FinishedAt = null;
        }        
        public void Update(string title, string description, decimal totalCost)
        {
            this.Title = title;
            this.TotalCost = totalCost;
            this.Description = description;
        }
    }
}
