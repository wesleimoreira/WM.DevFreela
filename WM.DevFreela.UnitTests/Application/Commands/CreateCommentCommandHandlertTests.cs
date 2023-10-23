using NSubstitute;
using WM.DevFreela.Application.Commands.CreateProject;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlertTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrage
            var projectRepositoryMock = Substitute.For<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title",
                ClienteId = 1,
                FreelanderId = 2,
                TotalCost = 10000,
                Description = "Description"
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Asserts
            Assert.True(id >= 0);
            await projectRepositoryMock.Received(1).AddAsync(Arg.Any<Project>());
        }
    }
}
