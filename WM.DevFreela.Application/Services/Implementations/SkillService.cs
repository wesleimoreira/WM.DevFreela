using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WM.DevFreela.Application.Services.Interfaces;
using WM.DevFreela.Application.ViewModels;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public IEnumerable<SkillViewModel> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT ID, Description, FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
        }
    }
}
