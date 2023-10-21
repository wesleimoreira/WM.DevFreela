using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using WM.DevFreela.Api.Configuration;
using WM.DevFreela.Application.Commands.CreateComment;
using WM.DevFreela.Application.Validators;
using WM.DevFreela.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(CreateCommentCommand));
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration.GetConnectionString("DevFreelaCs"));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
