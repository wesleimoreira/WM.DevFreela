using NSubstitute;
using WM.DevFreela.Application.Queries.GetAllSkills;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task GetAllShillExist_Execute_ReturnListSkillsDto()
        {
            var skillList = new List<Skill>
            {
                new Skill(description: "descriptions 1 Skill"),
                new Skill(description: "descriptions 2 Skill"),
                new Skill(description: "descriptions  3 Skill")
            };

            var skillRepositoryMock = Substitute.For<ISkillRepository>();

            skillRepositoryMock.GetAllAsync().Returns(skillList);

            var getAllSkillQuery = new GetAllSkillsQuery();

            var getAllSkillQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock);

            //Atc
           var skillResult =  await getAllSkillQueryHandler.Handle(getAllSkillQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillResult);
            Assert.Equal(skillResult.Count(), skillList.Count);
        }
    }
}
