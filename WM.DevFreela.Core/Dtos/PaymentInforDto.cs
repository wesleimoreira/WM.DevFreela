namespace WM.DevFreela.Core.Dtos
{
    public class PaymentInforDto
    {
        public PaymentInforDto(int idProject, string cvv, decimal amount, string fullName, string expiresAt, string creditCardNumber)
        {
            IdProject = idProject;
            Cvv = cvv;
            Amount = amount;
            FullName = fullName;
            ExpiresAt = expiresAt;
            CreditCardNumber = creditCardNumber;
        }

        public int IdProject { get; private set; }
        public string Cvv { get; private set; }
        public decimal Amount { get; private set; }
        public string FullName { get; private set; }
        public string ExpiresAt { get; private set; }
        public string CreditCardNumber { get; private set; }
    }
}
