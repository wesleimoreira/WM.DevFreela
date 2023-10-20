
#### Esse projeto está sendo desenvolvido como base de estudo do curso MÉTODO .NET DIRETO AO PONTO tendo como instrutor Luis Felipe (Lus Dev)

# Oque foi utilizado nesse projeto
-- clean architecture
-- CQRL (significa Segregação de Responsabilidade de Comando e Consulta)
-- Repository Pattern
-- Sql Server
-- EntityFrameworkCore
-- Dapper
-- MediatR


# Comandos para Migrations
 dotnet ef migrations add InitialMigration -s ../WM.DevFreela.Api/WM.DevFreela.Api.csproj -o ./Persistence/Migrations
 dotnet ef database update -s ,,.WM.DevFreela.Api
 