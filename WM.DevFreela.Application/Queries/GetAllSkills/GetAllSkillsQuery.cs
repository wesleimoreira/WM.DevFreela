using MediatR;
using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<IEnumerable<SkillDto>>
    {

    }
}
