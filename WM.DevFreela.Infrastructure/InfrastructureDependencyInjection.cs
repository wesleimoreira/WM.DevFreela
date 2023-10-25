using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.DevFreela.Core.Repositories;
using WM.DevFreela.Core.Services;
using WM.DevFreela.Infrastructure.Auth;
using WM.DevFreela.Infrastructure.MessageBus;
using WM.DevFreela.Infrastructure.Payments;
using WM.DevFreela.Infrastructure.Persistence;
using WM.DevFreela.Infrastructure.Persistence.Repositories;

namespace WM.DevFreela.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static void AddInfrastructureDependencyInjection(this IServiceCollection services, string connectionString)
        {  
            // DB
            services.AddDbContext<DevFreelaDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => { b.MigrationsAssembly("WM.DevFreela.Infrastructure"); });
            });

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
        }
    }
}
