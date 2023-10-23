using NSubstitute;
using WM.DevFreela.Application.Queries.GetUser;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.UnitTests.Application.Queries
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async Task UserExist_Execute_ReturnsListOfUsers()
        {
            // Arrage
            var user = new User(fullName: "weslei", email: "weslei@gmail.com", password: "123456", role: "Client", birthDate: DateTime.Now);

            var userRepositoryMock = Substitute.For<IUserRepository>();

            userRepositoryMock.GetById(1).Returns(user);

            var GetUserQuery = new GetUserQuery(1);

            var GetUserQueryHandler = new GetUserQueryHandler(userRepositoryMock);

            // Atc
            var userResult = await GetUserQueryHandler.Handle(GetUserQuery, new CancellationToken());

            // Assert
            Assert.NotNull(userResult);
            await userRepositoryMock.Received(1).GetById(1);
        }
    }
}
