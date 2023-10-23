
#### Esse projeto está sendo desenvolvido como base de estudo do curso MÉTODO .NET DIRETO AO PONTO tendo como instrutor Luis Felipe (Lus Dev)
## Será desenvolvido uma ferramenta onde o cliente cadastrara os projetos e o freelancer será cadastrado/convocado para implementar esse projeto.

# Oque foi utilizado nesse projeto
-- clean architecture
-- CQRL (Command e Query)
-- Repository Pattern
-- Sql Server
-- EntityFrameworkCore
-- MediatR
-- FluentValidation 
-- Autenticação e Autorização com JWT
-- Unit Test
---- XUnit (teste unitários)
---- NSubstitute (Mocks)
---- Pattern AAA (Arrange - Act - Assert)
---- Pattern Given_When_Then

# Comandos para Migrations
 dotnet ef migrations add InitialMigration -s ../WM.DevFreela.Api/WM.DevFreela.Api.csproj -o ./Persistence/Migrations
 dotnet ef database update -s ../WM.DevFreela.Api
 