namespace WM.DevFreela.Application.Queries.GetAllSkills
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string description, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
