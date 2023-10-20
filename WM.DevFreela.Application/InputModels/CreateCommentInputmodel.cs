namespace WM.DevFreela.Application.InputModels
{
    public class CreateCommentInputmodel
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
    }
}
