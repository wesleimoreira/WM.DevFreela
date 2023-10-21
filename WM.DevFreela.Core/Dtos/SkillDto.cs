namespace WM.DevFreela.Core.Dtos
{
    public class SkillDto
    {
        public SkillDto(int id, string description, DateTime createdAt)
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
