using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPaymentAsync(PaymentInforDto paymentInforDto);
    }
}
