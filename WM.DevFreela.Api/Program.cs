using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Application.Services.Implementations;
using WM.DevFreela.Application.Services.Interfaces;
using WM.DevFreela.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DevFreelaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaCs"), b =>
    {
        b.MigrationsAssembly("WM.DevFreela.Infrastructure");
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

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
