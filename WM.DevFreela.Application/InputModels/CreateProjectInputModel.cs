namespace WM.DevFreela.Application.InputModels
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }
        public int ClienteId { get; set; }
        public int FreelanderId { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
    }
}
