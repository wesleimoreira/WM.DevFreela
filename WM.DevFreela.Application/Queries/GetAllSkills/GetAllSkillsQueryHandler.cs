using MediatR;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillDto>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return (from skill in await _skillRepository.GetAllAsync()
                    select new SkillDto(skill.Id, skill.Description, skill.CreatedAt))
                  .ToList();
        }
    }
}
