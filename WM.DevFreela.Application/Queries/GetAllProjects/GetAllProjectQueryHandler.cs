using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WM.DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, IEnumerable<ProjectViewModel>>
    {
        private readonly string _connectionString;
        public GetAllProjectQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<IEnumerable<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Title, Description, TotalCost, CreatedAt FROM Projects;";

                var projects = await sqlConnection.QueryAsync<ProjectViewModel>(script);

                return projects.ToList();
            }
        }
    }
}
