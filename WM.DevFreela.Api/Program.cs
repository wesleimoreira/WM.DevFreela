using MediatR;
using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Application.Commands.CreateProject;
using WM.DevFreela.Infrastructure.Persistence;

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
