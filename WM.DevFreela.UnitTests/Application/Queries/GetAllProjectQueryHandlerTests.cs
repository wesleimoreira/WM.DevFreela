using NSubstitute;
using WM.DevFreela.Application.Queries.GetAllProjects;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectDto()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Project 1", 1, 1, 10000, "description 1"),
                new Project("Project 2", 2, 2, 20000, "description 2"),
                new Project("Project 3", 3, 3, 30000, "description 3"),
            };

            var projectRepositoryMock = Substitute.For<IProjectRepository>();

            projectRepositoryMock.GetAllAsync().Returns(projects);

            var getAllProjectQuery = new GetAllProjectQuery("");

            var getAllProjectQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock);

            // Act
            var projectDtoList = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());


            // Assert
            Assert.NotNull(projectDtoList);
            Assert.NotEmpty(projectDtoList);
            Assert.Equal(projects.Count, projectDtoList.Count());
            await projectRepositoryMock.Received(1).GetAllAsync();
        }
    }
}
