using WM.DevFreela.Api.Configuration;
using WM.DevFreela.Application;
using WM.DevFreela.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationDependencyInjection();

builder.Services.AddSwaggerConfiguration(builder.Configuration);

builder.Services.AddInfrastructureDependencyInjection(builder.Configuration.GetConnectionString("DevFreelaCs"));

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
