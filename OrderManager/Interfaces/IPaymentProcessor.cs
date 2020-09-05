using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface IPaymentProcessor
    {
        void ChargeCreditCard(string cardNumber, DateTime cardExpiryDate);
    }
}
