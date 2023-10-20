using MediatR;

namespace WM.DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<IEnumerable<SkillViewModel>>
    {

    }
}
