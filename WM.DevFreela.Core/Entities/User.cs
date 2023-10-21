namespace WM.DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string password, string role, DateTime birthDate)
        {
            Role = role;
            Email = email;
            Active = true;
            FullName = fullName;
            Password = password;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;

            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public bool Active { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Password {  get; private set; }   
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }



        public IEnumerable<UserSkill> Skills { get; private set; }
        public IEnumerable<Project> OwnedProjects { get; private set; }
        public IEnumerable<ProjectComment> Comments { get; private set; }
        public IEnumerable<Project> FreelanceProjects { get; private set; }
    }
}
