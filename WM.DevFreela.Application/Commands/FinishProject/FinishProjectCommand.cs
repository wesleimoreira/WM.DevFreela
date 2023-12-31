﻿using MediatR;

namespace WM.DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public FinishProjectCommand(int id, string cvv, decimal amount, string fullName, string expiresAt, string creditCardNumber)
        {
            Id = id;
            Cvv = cvv;
            Amount = amount;
            FullName = fullName;
            ExpiresAt = expiresAt;
            CreditCardNumber = creditCardNumber;
        }

        public int Id { get;  set; }      
        public string Cvv { get; private set; }
        public decimal Amount { get; private set; }
        public string FullName { get; private set; }
        public string ExpiresAt { get; private set; }
        public string CreditCardNumber { get; private set; }
    }
}
