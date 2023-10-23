using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Enums;

namespace WM.DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project(title: "Titulo do projeto", clienteId: 1, freelancerId: 2, totalCost: 12000, description: "Descrição para o projeto");

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            Assert.Null(project.StartedAt);
            Assert.Equal(ProjectStatusEnum.Created, project.Status);            

            project.Start();

            Assert.NotNull(project.StartedAt);
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        }
    }
}
