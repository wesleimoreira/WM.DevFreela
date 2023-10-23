using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Enums;

namespace WM.DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        private readonly Project _project  = new(title: "Titulo do projeto", clienteId: 1, freelancerId: 2, totalCost: 12000, description: "Descrição para o projeto");


        [Fact]
        public void ProjectCreate_Execute_ReturnStatusStart() 
        {
            Assert.NotNull(_project.CreatedAt);
            Assert.Equal(ProjectStatusEnum.Created, _project.Status);

            _project.Start();

            Assert.NotNull(_project.StartedAt);
            Assert.Equal(ProjectStatusEnum.InProgress, _project.Status);
        }

        [Fact]
        public void ProjectInProgress_Execure_ReturnStatusFish() 
        {
            _project.Start();

            Assert.NotNull(_project.StartedAt);
            Assert.Equal(ProjectStatusEnum.InProgress, _project.Status);

            _project.Finish();

            Assert.NotNull(_project.FinishedAt);
            Assert.Equal(ProjectStatusEnum.Finished, _project.Status);
        }

        [Fact]
        public void ProjectInProgress_Execute_ReturnStatusCanceled()
        {
            _project.Start();

            Assert.NotNull(_project.StartedAt);
            Assert.Equal(ProjectStatusEnum.InProgress, _project.Status);

            _project.Cancel();
           
            Assert.Equal(ProjectStatusEnum.Cancelled, _project.Status);
        }
    }
}
