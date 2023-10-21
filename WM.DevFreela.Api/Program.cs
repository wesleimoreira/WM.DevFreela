using FluentValidation;
using MediatR;
using WM.DevFreela.Api.Filters;
using WM.DevFreela.Application.Commands.CreateComment;
using WM.DevFreela.Application.Validators;
using WM.DevFreela.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(CreateCommentCommand));
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration.GetConnectionString("DevFreelaCs"));

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
