using NSubstitute;
using WM.DevFreela.Application.Queries.GetProjectById;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task GetProjectByIdExist_Execute_ReturnProjectDetailsDto() 
        {
            // Arrage
            var project = new Project("Project 1", 1, 1, 10000, "description 1")
            {
                Client = new User(fullName: "weslei", email: "weslei@gmail.com", password: "123456", role: "Client", birthDate: DateTime.Now),
                Freelancer = new User(fullName: "weslei", email: "weslei@gmail.com", password: "123456", role: "Client", birthDate: DateTime.Now)
            };

            var projectRepositoryMock = Substitute.For<IProjectRepository>();

            projectRepositoryMock.GetByIdAsync(1).Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(1);

            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock);

            // Act
            var projectResult = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectResult);
            Assert.NotEmpty(projectResult.ClientFullName);
            Assert.NotEmpty(projectResult.FreelancerFullName);
            await projectRepositoryMock.Received(1).GetByIdAsync(1);
        }
    }
}
