using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WM.DevFreela.Application.Commands.CreateComment;
using WM.DevFreela.Application.Consumers;

namespace WM.DevFreela.Application
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCommentCommand));
            services.AddHostedService<PaymentApprovedConsumer>();

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
