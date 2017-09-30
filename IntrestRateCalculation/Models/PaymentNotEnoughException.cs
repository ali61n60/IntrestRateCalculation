using System;
using System.Runtime.Serialization;

namespace IntrestRateCalculation.Models
{
    [Serializable]
    internal class PaymentNotEnoughException : Exception
    {
        public PaymentNotEnoughException()
        {
        }

        public PaymentNotEnoughException(string message) : base(message)
        {
        }
    }
}