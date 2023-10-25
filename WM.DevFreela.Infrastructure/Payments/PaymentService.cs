using System.Text.Json;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Services;

namespace WM.DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPaymentAsync(PaymentInforDto paymentInforDto)
        {
            var paymentInfoBytes = JsonSerializer.SerializeToUtf8Bytes(paymentInforDto);

            _messageBusService.Publish(queue: "Payments", message: paymentInfoBytes);
        }
    }
}
