using MediatR;
using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.AddAsync(new User(request.FullName, request.Email, request.BirthDate), cancellationToken);

            if (user.State == EntityState.Added)
                await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Entity.Id;
        }
    }
}
