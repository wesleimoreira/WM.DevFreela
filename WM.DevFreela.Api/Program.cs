using MediatR;
using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Application.Commands.CreateProject;
using WM.DevFreela.Core.Repositories;
using WM.DevFreela.Infrastructure.Persistence;
using WM.DevFreela.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateProjectCommand));

builder.Services.AddDbContext<DevFreelaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaCs"), b =>
    {
        b.MigrationsAssembly("WM.DevFreela.Infrastructure");
    });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

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
