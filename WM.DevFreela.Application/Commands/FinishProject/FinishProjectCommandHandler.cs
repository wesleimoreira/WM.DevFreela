using MediatR;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Repositories;
using WM.DevFreela.Core.Services;

namespace WM.DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IPaymentService _paymentService;
        private readonly IProjectRepository _projectRepository;

        public FinishProjectCommandHandler(IProjectRepository repository, IPaymentService paymentService)
        {
            _projectRepository = repository;
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInforDto(request.Id, request.Cvv, request.Amount, request.FullName, request.ExpiresAt, request.CreditCardNumber);

            _paymentService.ProcessPaymentAsync(paymentInfoDto);

            project.SetPaymentPending();

            await _projectRepository.SaveChangesAsync();

            return true;
        }
    }
}
